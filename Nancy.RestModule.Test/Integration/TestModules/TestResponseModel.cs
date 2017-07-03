namespace Nancy.RestModule.Test.Integration.TestModules
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