using System;

namespace Generics.Test
{
    internal class Threeple<TFirst, TSecond, TThird>
    {

        public TFirst First { get; }
        public TSecond  Second { get; }
        public TThird Third { get; }
        public string Description { 
            get 
            {
                return $"First: {First.Description}; Second: {Second.ToString()}; Third: ;";
            } 
        }

        public Threeple(TFirst first, TSecond second, TThird third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }

    internal class ThreepleDescrition<TFirst, TSecond, TThird, TFourth>
        where TFirst : IDescription
    {

        public TFirst First { get; }
        public TSecond  Second { get; }
        public TThird Third { get; }
        public string Description { 
            get 
            {
                return $"First: {First.Description}; Second: {Second.ToString()}; Third: ;";
            } 
        }

        public ThreepleDescrition(TFirst first, TSecond second, TThird third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }
}
