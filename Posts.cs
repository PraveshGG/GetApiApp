using System;
namespace Application
{
    // A field is a variable of any type that is declared directly in a class
    // fields become property in c# when we add a getter and setter functionality to them which are properties but they also acts like functions.

    public class Posts
    {
        // we are using public becuase we want to use these properties
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        // constructor methods
        // a constructor has the same name as the class name
        // the construct is called as soon as the object is created or constructed

        // create a empty contructor to use if no data is available to import
        public Posts()
        {

        }
    }

}
