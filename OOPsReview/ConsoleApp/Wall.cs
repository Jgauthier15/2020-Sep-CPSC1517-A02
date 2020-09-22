using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Wall
    {
        // height, width
        //height and width > 0.0
        //height has a default of 2.5m, width is 4.25m
        //Area and Perimeter
        //Throw exceptions for invalid data

        private decimal _Height;
        private decimal _Width;

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
        public Wall()
        {
            Height = 2.5m;
            Width = 4.25m;
        }


        //Greedy Constructor
        public Wall(decimal width, decimal height)
        {
            Width = width;
            Height = height;
        }

        //Behaviours
        public decimal WallArea()
        {
            return Height * Width;
        }
    }
}
