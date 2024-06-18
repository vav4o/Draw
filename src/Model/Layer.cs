using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    public class Layer
    {
        [JsonConstructor]
        public Layer(string name)
        {
            this.name = name;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private List<Shape> shapes = new List<Shape>();
        public List<Shape> Shapes
        {
            get { return shapes; }
            set { shapes = value; }
        }
        public override bool Equals(object obj)
        {
            if (obj == this)
                return false;

            if (obj == null || obj.GetType() != this.GetType())
                return false;

            Layer other = (Layer)obj;
            return this.name == other.name;
        }
    }
}
