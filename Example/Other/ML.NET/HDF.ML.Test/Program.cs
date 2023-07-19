using Microsoft.ML;
using Microsoft.ML.Data;

internal class Program
{
    /// <summary>
    /// 线性回归算法的预测结果，新列固定名称
    /// </summary>
    const string RegressionColumnName = "Score";

    public class HouseData
    {
        public float Size { get; set; }
        public float Price { get; set; }
    }

    public class Prediction2
    {
        [ColumnName(RegressionColumnName)]
        public float Price { get; set; }
    }

    private static void Main(string[] args)
    {


        Train();

        Use();

    }




    static void Train()
    {

        MLContext mlContext = new MLContext();

        // 1. Import or create training data
        HouseData[] houseData = Enumerable.Range(1, 10_0000).Select(i => new HouseData() { Size = i, Price = i * 2 }).ToArray();
        IDataView trainingData = mlContext.Data.LoadFromEnumerable(houseData);

        /*
        所有 ML.NET 算法都在寻找属于向量的输入列。 默认情况下，此向量列称为特征（Features）。 
        这就是我们在房屋价格示例中将大小（Size）列连接到名为特征(Features)的新列中的原因。
         */

        // 2. Specify data preparation and model training pipeline
        var pipeline = mlContext.Transforms
            .Concatenate("Features", new[] { "Size" })
            .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "Price", maximumNumberOfIterations: 100));

        // 3. Train model
        var model = pipeline.Fit(trainingData);

        // 4. Make a prediction
        var size = new HouseData() { Size = 2.5F };
        var price = mlContext.Model.CreatePredictionEngine<HouseData, Prediction2>(model).Predict(size);

        Console.WriteLine($"Predicted price for size: {size.Size * 1000} sq ft= {price.Price * 100:C}k");

        // Predicted price for size: 2500 sq ft= $261.98k



        // mlContext.Model.Save(model, trainingData.Schema, @"C:\Users\12131\Desktop\666");



    }


    static void Use()
    {

        MLContext mlContext = new MLContext();

        var model = mlContext.Model.Load(@"C:\Users\12131\Desktop\666", out var dataViewSchema);



        var size = new HouseData() { Size = 2.5F };
        var price = mlContext.Model.CreatePredictionEngine<HouseData, Prediction2>(model).Predict(size);










    }





}