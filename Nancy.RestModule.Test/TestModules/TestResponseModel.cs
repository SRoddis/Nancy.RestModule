namespace Nancy.RestModule.Test.TestModules
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