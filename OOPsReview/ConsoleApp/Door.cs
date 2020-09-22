using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Door
    {
        // height, width, meterial (nullable), right or left swinging door
        //height and width > 0
        //height has a default of 1.75m, width is 1.2m
        //right or left are indicated with an R or L
        //Area and Perimeter
        //Throw exceptions for invalid data


        private string _Material;
        private decimal _Height;
        private decimal _Width;
        private string _RightOrLeft;

        public string Material
        {
            get
            {
                return _Material;
            }
            set
            {
                _Material = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        
        public string RightOrLeft
        {
            get
            {
                return _RightOrLeft;
            }
            set
            {
                if (value.ToUpper().Equals("R") || value.ToUpper().Equals("L"))
                {
                    _RightOrLeft = value.ToUpper();
                }
                else
                {
                    throw new Exception("Door opening must be R (right) or L (left)");
                }
            }
        }
        public decimal Height
        {
            //Height must be greater than 0
            get 
            { 
                return _Height; 
            }
            set
            {
                //the m indicates the value is a decimal
                if (value <= 0.0m)
                {
                    throw new Exception("Height cannot be 0 or less than 0.");
                }
                else
                {
                    _Height = value;
                }
            }
        }

        public decimal Width
        {
            //Width must be greater than 0
            get { return _Width; }
            set
            {
                //the m indicated the value is a decimal
                if (value <= 0.0m)
                {
                    throw new Exception("Width cannot be 0 or less than 0.");
                }
                else
                {
                    _Width = value;
                }
            }
        }
        //Default Constructor
        public Door()
        {
            Height = 1.75m;
            Width = 1.2m;
            RightOrLeft = "R";  //could be "L"

        }

        //Greedy Constructor
        public Door(decimal width, decimal height, string material, string rightorleft)
        {
            Width = width;
            Height = height;
            Material = material;
            RightOrLeft = rightorleft;
        }

        //Behaviours
        public decimal DoorArea()
        {
            return Height * Width;
        }
        public decimal DoorPerimeter()
        {
            return 2 * (Height + Width);
        }
    }
}
