namespace Nancy.RestModule.Test.TestModels
{
    public class TestResponseModel
    {
        public TestResponseModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}