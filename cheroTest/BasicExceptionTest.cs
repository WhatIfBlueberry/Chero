using chero;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cheroTest
{
    [TestClass]
    public class BasicExceptionTest
    {
        [TestMethod]
        public void runExceptionTest()
        {
            string folderPath = @"..\..\..\testfiles";
            string fullPath = Path.GetFullPath(folderPath); // get the full path of the folder
            string[] fileNames = Directory.GetFiles(fullPath);
            foreach (string fileName in fileNames)
            {
                try
                {
                    string[] lines = File.ReadAllLines(fileName);
                    List<MoveAction> parsedActions = InputParser.parse(lines);
                    Engine engine = new Engine(new Chero(), parsedActions);
                    engine.transform().ForEach(action => Console.WriteLine(action));
                    Helper.reset();
                }
                catch (Exception ex)
                {
                    Assert.Fail("Parsing File: " + fileName + " - Expected no exception, but got: " + ex.Message);
                }
                
            }
        }
    }
}
