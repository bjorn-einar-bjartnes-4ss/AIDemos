﻿using System;
using System.IO;

namespace IsAffirmative
{
    class Program
    {
        static readonly string _trainDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "AffirmativeCorpus.csv");
        static readonly string _testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "AffirmativeTest.csv");

        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");
        static readonly string _base64ModelPath = Path.Combine(Environment.CurrentDirectory, "Data", "EncodedModel.txt");
        static readonly string _base64EncodedModel = "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AAAAAAAAAMMFAABUcmFuc2Zvcm1lckNoYWluXFRyYW5zZm9ybV8wMDBcVHJhbnNmb3JtXzAwMFxTdGVwXzAwMVxNb2RlbC5rZXlQSwECFAAUAAAACABIAlJOVI1Pp6IEAABHCAAAUQAAAAAAAAAAAAAAAADQBgAAVHJhbnNmb3JtZXJDaGFpblxUcmFuc2Zvcm1fMDAwXFRyYW5zZm9ybV8wMDBcU3RlcF8wMDJcTWFwcGVyXFZvY2FidWxhcnlcVGVybXMudHh0UEsBAhQAFAAAAAgASAJSTl+qaV8+BwAA8RIAAFEAAAAAAAAAAAAAAAAA4QsAAFRyYW5zZm9ybWVyQ2hhaW5cVHJhbnNmb3JtXzAwMFxUcmFuc2Zvcm1fMDAwXFN0ZXBfMDAyXE1hcHBlclxWb2NhYnVsYXJ5XE1vZGVsLmtleVBLAQIUABQAAAAIAEgCUk4CtrFgAQEAAE0CAABGAAAAAAAAAAAAAAAAAI4TAABUcmFuc2Zvcm1lckNoYWluXFRyYW5zZm9ybV8wMDBcVHJhbnNmb3JtXzAwMFxTdGVwXzAwMlxNYXBwZXJcTW9kZWwua2V5UEsBAhQAFAAAAAgASAJSTq8GW1SwAAAAsAEAAD8AAAAAAAAAAAAAAAAA8xQAAFRyYW5zZm9ybWVyQ2hhaW5cVHJhbnNmb3JtXzAwMFxUcmFuc2Zvcm1fMDAwXFN0ZXBfMDAyXE1vZGVsLmtleVBLAQIUABQAAAAIAEgCUk7hwZ1kZwMAAGQGAABGAAAAAAAAAAAAAAAAAAAWAABUcmFuc2Zvcm1lckNoYWluXFRyYW5zZm9ybV8wMDBcVHJhbnNmb3JtXzAwMFxTdGVwXzAwM1xNYXBwZXJcTW9kZWwua2V5UEsBAhQAFAAAAAgASAJSTq8GW1SwAAAAsAEAAD8AAAAAAAAAAAAAAAAAyxkAAFRyYW5zZm9ybWVyQ2hhaW5cVHJhbnNmb3JtXzAwMFxUcmFuc2Zvcm1fMDAwXFN0ZXBfMDAzXE1vZGVsLmtleVBLAQIUABQAAAAIAEgCUk7R1mDo9QAAAGYCAABGAAAAAAAAAAAAAAAAANgaAABUcmFuc2Zvcm1lckNoYWluXFRyYW5zZm9ybV8wMDBcVHJhbnNmb3JtXzAwMFxTdGVwXzAwNFxNYXBwZXJcTW9kZWwua2V5UEsBAhQAFAAAAAgASAJSTq8GW1SwAAAAsAEAAD8AAAAAAAAAAAAAAAAAMRwAAFRyYW5zZm9ybWVyQ2hhaW5cVHJhbnNmb3JtXzAwMFxUcmFuc2Zvcm1fMDAwXFN0ZXBfMDA0XE1vZGVsLmtleVBLAQIUABQAAAAIAEgCUk4dTMHG5QwAAP4ZAABGAAAAAAAAAAAAAAAAAD4dAABUcmFuc2Zvcm1lckNoYWluXFRyYW5zZm9ybV8wMDBcVHJhbnNmb3JtXzAwMFxTdGVwXzAwNVxNYXBwZXJcTW9kZWwua2V5UEsBAhQAFAAAAAgASAJSTq8GW1SwAAAAsAEAAD8AAAAAAAAAAAAAAAAAhyoAAFRyYW5zZm9ybWVyQ2hhaW5cVHJhbnNmb3JtXzAwMFxUcmFuc2Zvcm1fMDAwXFN0ZXBfMDA1XE1vZGVsLmtleVBLAQIUABQAAAAIAEgCUk5WIwNCGwEAANgCAABGAAAAAAAAAAAAAAAAAJQrAABUcmFuc2Zvcm1lckNoYWluXFRyYW5zZm9ybV8wMDBcVHJhbnNmb3JtXzAwMFxTdGVwXzAwNlxNYXBwZXJcTW9kZWwua2V5UEsBAhQAFAAAAAgASAJSTq8GW1SwAAAAsAEAAD8AAAAAAAAAAAAAAAAAEy0AAFRyYW5zZm9ybWVyQ2hhaW5cVHJhbnNmb3JtXzAwMFxUcmFuc2Zvcm1fMDAwXFN0ZXBfMDA2XE1vZGVsLmtleVBLAQIUABQAAAAIAEgCUk7wlfvGGQEAAJgCAABGAAAAAAAAAAAAAAAAACAuAABUcmFuc2Zvcm1lckNoYWluXFRyYW5zZm9ybV8wMDBcVHJhbnNmb3JtXzAwMFxTdGVwXzAwN1xNYXBwZXJcTW9kZWwua2V5UEsBAhQAFAAAAAgASAJSTq8GW1SwAAAAsAEAAD8AAAAAAAAAAAAAAAAAnS8AAFRyYW5zZm9ybWVyQ2hhaW5cVHJhbnNmb3JtXzAwMFxUcmFuc2Zvcm1fMDAwXFN0ZXBfMDA3XE1vZGVsLmtleVBLAQIUABQAAAAIAEgCUk4IwIigRAEAAMcDAAA/AAAAAAAAAAAAAAAAAKowAABUcmFuc2Zvcm1lckNoYWluXFRyYW5zZm9ybV8wMDBcVHJhbnNmb3JtXzAwMFxTdGVwXzAwOFxNb2RlbC5rZXlQSwECFAAUAAAACABIAlJObX0PuLkAAADAAQAANgAAAAAAAAAAAAAAAABLMgAAVHJhbnNmb3JtZXJDaGFpblxUcmFuc2Zvcm1fMDAwXFRyYW5zZm9ybV8wMDBcTW9kZWwua2V5UEsBAhQAFAAAAAgASAJSTjOqs3RICgAAhBIAAEYAAAAAAAAAAAAAAAAAWDMAAFRyYW5zZm9ybWVyQ2hhaW5cVHJhbnNmb3JtXzAwMFxUcmFuc2Zvcm1fMDAxXE1vZGVsXFByZWRpY3RvclxNb2RlbC5rZXlQSwECFAAUAAAACABIAlJOaEK92DwAAAA6AAAATAAAAAAAAAAAAAAAAAAEPgAAVHJhbnNmb3JtZXJDaGFpblxUcmFuc2Zvcm1fMDAwXFRyYW5zZm9ybV8wMDFcTW9kZWxcQ2FsaWJyYXRvclxDYWxpYnJhdG9yLnR4dFBLAQIUABQAAAAIAEgCUk4cclPtvgAAAMABAABHAAAAAAAAAAAAAAAAAKo+AABUcmFuc2Zvcm1lckNoYWluXFRyYW5zZm9ybV8wMDBcVHJhbnNmb3JtXzAwMVxNb2RlbFxDYWxpYnJhdG9yXE1vZGVsLmtleVBLAQIUABQAAAAIAEgCUk6+D+9AtAAAALABAAA8AAAAAAAAAAAAAAAAAM0/AABUcmFuc2Zvcm1lckNoYWluXFRyYW5zZm9ybV8wMDBcVHJhbnNmb3JtXzAwMVxNb2RlbFxNb2RlbC5rZXlQSwECFAAUAAAACABIAlJODTtVrH8UAAAvFgAAOAAAAAAAAAAAAAAAAADbQAAAVHJhbnNmb3JtZXJDaGFpblxUcmFuc2Zvcm1fMDAwXFRyYW5zZm9ybV8wMDFcVHJhaW5TY2hlbWFQSwECFAAUAAAACABIAlJO4gqQe9MAAADmAQAANgAAAAAAAAAAAAAAAACwVQAAVHJhbnNmb3JtZXJDaGFpblxUcmFuc2Zvcm1fMDAwXFRyYW5zZm9ybV8wMDFcTW9kZWwua2V5UEsBAhQAFAAAAAgASAJSTuRFIUPAAAAAvAEAACgAAAAAAAAAAAAAAAAA11YAAFRyYW5zZm9ybWVyQ2hhaW5cVHJhbnNmb3JtXzAwMFxNb2RlbC5rZXlQSwECFAAUAAAACABIAlJO96CdGb4AAAC4AQAAGgAAAAAAAAAAAAAAAADdVwAAVHJhbnNmb3JtZXJDaGFpblxNb2RlbC5rZXlQSwUGAAAAAB8AHwApDQAA01gAAAAAAAAAAAAAAAAAAA==";

        static void Main(string[] args)
        {
            bool train = true;

            Classifier.MLDotNet.AffirmativeClassifier model;
            if (train)
            {
                // Train a new model using training data
                model = new Classifier.MLDotNet.AffirmativeClassifier(_trainDataPath, _testDataPath);

                // Store the trained model
                var savedModel = model.Export();
                var encodedModel = Convert.ToBase64String(savedModel, Base64FormattingOptions.None);
                File.WriteAllText(_base64ModelPath, encodedModel);
                Console.WriteLine($"Model trained using: {model.TrainingMethodName}");
                Console.WriteLine($"Encoded model stored in '{_base64ModelPath}'\r\n");
            }
            else
            {
                // Load an existing model
                byte[] modelData = System.Convert.FromBase64String(_base64EncodedModel);
                model = new Classifier.MLDotNet.AffirmativeClassifier(modelData);
            }

            var evaluationResults = model.Evaluate(_testDataPath);
            DisplayEvaluationResults(evaluationResults.Accuracy, evaluationResults.Auc, evaluationResults.F1Score);
            DisplayTestDataResults(model, _testDataPath);

            string input = string.Empty;
            do
            {
                Console.Write("\n\nUtterance: ");
                input = Console.ReadLine();
                if (input != string.Empty)
                {
                    var result = model.Predict(input);
                    DisplayPredictionResults(input, result.Prediction, result.Probability);
                }
            }
            while (input != string.Empty);
        }

        public static void DisplayEvaluationResults(double accuracy, double auc, double f1Score)
        {
            Console.WriteLine("=============== Model Evaluation Results with Test data===============");
            Console.WriteLine($"Accuracy: {accuracy:P2}");
            Console.WriteLine($"Auc: {auc:P2}");
            Console.WriteLine($"F1Score: {f1Score:P2}");
            Console.WriteLine();
        }

        public static void DisplayTestDataResults(Classifier.MLDotNet.AffirmativeClassifier model, string testDataPath)
        {
            var dataView = System.IO.File.ReadAllLines(testDataPath);

            Console.WriteLine("=============== Displaying Model Results with Test data===============");
            foreach (var item in dataView)
            {
                var elements = item.Split(',');
                if (elements[0].ToLower() != "isaffirmative")
                {
                    var prediction = model.Predict(elements[1]);
                    DisplayPredictionResults(elements[1], prediction.Prediction, prediction.Probability);
                }
            }

            Console.WriteLine();
        }

        public static void DisplayPredictionResults(string utterance, bool prediction, float probability)
        {
            Console.WriteLine($"Utterance:{utterance.PadRight(30)}\tPrediction:{(prediction ? "Affirmative    " : "Not Affirmative")}\tProbability: {probability} ");
        }

    }
}
