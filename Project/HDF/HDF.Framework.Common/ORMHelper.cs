using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace HDF.Framework.Common
{
    public static class ORMHelper
    {
        public enum SQLType
        {
            Select,
            Insert,
            Update,
            Delete,
        }

        public static string GenerateSimpleSQL<T>(this T obj, SQLType type, Expression<Func<T, bool>> expression = null) where T : class
        {
            if (obj == default)
                throw new ArgumentNullException(nameof(obj));

            string sqlWhere = "";
            if (expression != null)
            {
                SqlVisitor sqlVisitor = new SqlVisitor();
                sqlVisitor.Visit(expression);
                sqlWhere = sqlVisitor.GetSqlWhere();
            }

            switch (type)
            {
                case SQLType.Select:
                    return $"{GenerateSimpleSelectSQL(obj)} where { sqlWhere}";
                case SQLType.Insert:
                    return GenerateSimpleInsertSQL(obj);
                case SQLType.Update:
                    return $"{GenerateSimpleUpdateSQL(obj)} where { sqlWhere}";
                case SQLType.Delete:
                    return $"{GenerateSimpleDeleteSQL(obj)} where { sqlWhere}";
                default:
                    throw new ArgumentException(nameof(type));
            }

        }


        private static string GenerateSimpleSelectSQL<T>(T obj)
        {
            string sql = string.Join(",", obj.GetType().GetProperties().Select(p => $"[{p.Name}]"));
            return $"select [{sql}] from {obj.GetType().Name} ";
        }

        private static string GenerateSimpleInsertSQL<T>(T obj)
        {
            var props = obj.GetType().GetProperties();
            string sql1 = string.Join(",", props.Select(p => $"[{p.Name}]"));
            string sql2 = string.Join(",", props.Select(p => $"@{p.Name}"));
            return $"insert into [{obj.GetType().Name}]({sql1}) values ({sql2}) ";
        }

        private static string GenerateSimpleUpdateSQL<T>(T obj)
        {
            string sql = string.Join(",", obj.GetType().GetProperties().Select(p => $"[{p.Name}]=@{p.Name}"));
            return $"update [{obj.GetType().Name}] set {sql} ";
        }

        private static string GenerateSimpleDeleteSQL<T>(T obj)
        {
            return $"delete from [{obj.GetType().Name}] ";
        }

    }




    /// <summary>
    /// <remarks>解读表达式目录树</remarks>
    /// </summary>
    public class SqlVisitor : ExpressionVisitor
    {
        /// <summary>
        /// <remarks>SQL语句条件拼接</remarks>
        /// <remarks>stack:表示同一指定类型实例的可变大小后进先出（LIFO）集合</remarks>
        /// <remarks>string:指定堆栈中元素的类型</remarks>
        /// </summary>
        private readonly Stack<string> _sqlWhereStack = new Stack<string>();

        /// <summary>
        /// <remarks>返回解析后的SQL条件语句</remarks>
        /// </summary>
        /// <returns></returns>
        public string GetSqlWhere()
        {
            // SQL语句条件字符串
            string sqlWhereStr = string.Join(" ", _sqlWhereStack);
            // 清空栈
            _sqlWhereStack.Clear();
            // 返回SQL条件语句解析结果字符串
            return sqlWhereStr;
        }



        /// <summary>
        /// <remarks>二元表达式：解读条件</remarks>
        /// </summary>
        /// <param name="binaryExpression">二元表达式</param>
        /// <returns></returns>
        protected override Expression VisitBinary(BinaryExpression binaryExpression)
        {
            // 拼接右括号：堆栈先进后出原则拼接
            _sqlWhereStack.Push(")");
            // 解析表达式右边
            this.Visit(binaryExpression.Right);
            var param = _sqlWhereStack.Pop();
            _sqlWhereStack.Push("@" + param);
            // 解析操作类型
            _sqlWhereStack.Push(SqlOperator.ToSqlOperator(binaryExpression.NodeType));
            // 解析表达式左边
            this.Visit(binaryExpression.Left);
            // 拼接左括号
            _sqlWhereStack.Push("(");
            return binaryExpression;
        }



        /// <summary>
        /// <remarks>解析属性/字段表达式</remarks>
        /// </summary>
        /// <param name="memberExpression">属性/字段表达式</param>
        /// <returns></returns>
        protected override Expression VisitMember(MemberExpression memberExpression)
        {
            // 接收属性/字段名称
            string prop = memberExpression.Member.Name;
            // 将属性/字段名称存入栈中
            this._sqlWhereStack.Push(memberExpression.Member.Name);
            return memberExpression;
        }

        /// <summary>
        /// <remarks>解析常量表达式</remarks>
        /// </summary>
        /// <param name="constantExpression">常量表达式</param>
        /// <returns></returns>
        protected override Expression VisitConstant(ConstantExpression constantExpression)
        {
            // 将常量的值存入栈中
            this._sqlWhereStack.Push(constantExpression.Value.ToString());
            return constantExpression;
        }

        /// <summary>
        /// <remarks>解析函数表达式</remarks>
        /// </summary>
        /// <param name="methodCallExpression">函数表达式</param>
        /// <returns></returns>
        protected override Expression VisitMethodCall(MethodCallExpression methodCallExpression)
        {
            // 解析后的函数表达式
            string format;
            // 根据函数类型解析
            switch (methodCallExpression.Method.Name)
            {
                case "StartWith":
                    format = "({0} like '{1}%')";
                    break;
                case "Contains":
                    format = "({0} like '%{1}%')";
                    break;
                case "EndWith":
                    format = "({0} like '%{1}')";
                    break;
                case "Equals":
                    format = "({0} = '{1}')";
                    break;
                default:
                    throw new NotSupportedException(methodCallExpression.NodeType + " is not supported!");
            }

            // 调用方法的属性：例如（name.contains("1")）,这里就是指name属性调用的contains函数 
            Expression instance = this.Visit(methodCallExpression.Object);
            // 参数：1就代表调用contains函数传递的参数值
            Expression expressionArray = this.Visit(methodCallExpression.Arguments[0]);
            // 返回栈顶部的对象并删除
            string right = this._sqlWhereStack.Pop();
            string left = this._sqlWhereStack.Pop();
            // 将解析后的结果存入栈中
            this._sqlWhereStack.Push(String.Format(format, left, right));
            return methodCallExpression;
        }

    }

    /// <summary>
    /// <remarks>解析SQL语句中的操作类型</remarks>
    /// </summary>
    internal static class SqlOperator
    {
        /// <summary>
        /// <remarks>解析操作类型</remarks>
        /// </summary>
        internal static string ToSqlOperator(this ExpressionType expressionType)
        {
            // 将操作类型解析为对应的表达方式
            switch (expressionType)
            {
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
                case ExpressionType.Equal:
                    return "=";
                case ExpressionType.NotEqual:
                    return "<>";
                case ExpressionType.Not:
                    return "NOT";
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    return "AND";
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    return "OR";
                default:
                    throw new NotSupportedException(expressionType.ToString() + " is not supported!");
            }

        }

    }













}


