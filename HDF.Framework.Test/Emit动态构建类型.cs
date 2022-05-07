using System.Reflection.Emit;

namespace WinFormsApp1
{
    internal class Emit动态构建类型
    {

        public static void Test()
        {



            //TypeBuilder builder = TypeBuilder.


            AssemblyName aName = new AssemblyName("HDT.Test.DynamicAssembly");

            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndSave);

            ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");


            TypeBuilder tb = mb.DefineType("MyDynamicType", TypeAttributes.Public);



            FieldBuilder fbNumber = tb.DefineField(
                "m_number",
                typeof(int),
                FieldAttributes.Private);


            ConstructorBuilder ctor1 = tb.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                new[] { typeof(int) });






            ILGenerator ctor1IL = ctor1.GetILGenerator();


            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Call,
                typeof(object).GetConstructor(Type.EmptyTypes));
            // Push the instance on the stack before pushing the argument
            // that is to be assigned to the private field m_number.
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Ldarg_1);
            ctor1IL.Emit(OpCodes.Stfld, fbNumber);
            ctor1IL.Emit(OpCodes.Ret);



            PropertyBuilder pbNumber = tb.DefineProperty(
              "Number",
              System.Reflection.PropertyAttributes.HasDefault,
              typeof(int),
              null);


            // The property "set" and property "get" methods require a special
            // set of attributes.
            MethodAttributes getSetAttr = MethodAttributes.Public |
                MethodAttributes.SpecialName | MethodAttributes.HideBySig;

            // Define the "get" accessor method for Number. The method returns
            // an integer and has no arguments. (Note that null could be
            // used instead of Types.EmptyTypes)
            MethodBuilder mbNumberGetAccessor = tb.DefineMethod(
                "get_Number",
                getSetAttr,
                typeof(int),
                Type.EmptyTypes);

            ILGenerator numberGetIL = mbNumberGetAccessor.GetILGenerator();
            // For an instance property, argument zero is the instance. Load the
            // instance, then load the private field and return, leaving the
            // field value on the stack.
            numberGetIL.Emit(OpCodes.Ldarg_0);
            numberGetIL.Emit(OpCodes.Ldfld, fbNumber);
            numberGetIL.Emit(OpCodes.Ret);

            // Define the "set" accessor method for Number, which has no return
            // type and takes one argument of type int (Int32).
            MethodBuilder mbNumberSetAccessor = tb.DefineMethod(
                "set_Number",
                getSetAttr,
                null,
                new Type[] { typeof(int) });

            ILGenerator numberSetIL = mbNumberSetAccessor.GetILGenerator();
            // Load the instance and then the numeric argument, then store the
            // argument in the field.
            numberSetIL.Emit(OpCodes.Ldarg_0);
            numberSetIL.Emit(OpCodes.Ldarg_1);
            numberSetIL.Emit(OpCodes.Stfld, fbNumber);
            numberSetIL.Emit(OpCodes.Ret);


            pbNumber.SetGetMethod(mbNumberGetAccessor);
            pbNumber.SetSetMethod(mbNumberSetAccessor);



            MethodBuilder meth = tb.DefineMethod(
                "MyMethod",
                MethodAttributes.Public,
                typeof(int),
                new Type[] { typeof(int) });

            ILGenerator methIL = meth.GetILGenerator();
            // To retrieve the private instance field, load the instance it
            // belongs to (argument zero). After loading the field, load the
            // argument one and then multiply. Return from the method with
            // the return value (the product of the two numbers) on the
            // execution stack.
            methIL.Emit(OpCodes.Ldarg_0);
            methIL.Emit(OpCodes.Ldfld, fbNumber);
            methIL.Emit(OpCodes.Ldarg_1);
            methIL.Emit(OpCodes.Mul);
            methIL.Emit(OpCodes.Ret);


            // Finish the type.
            Type t = tb.CreateType();



            var res11 = Activator.CreateInstance(t, new object[] { 1 });





        }
    }
}
