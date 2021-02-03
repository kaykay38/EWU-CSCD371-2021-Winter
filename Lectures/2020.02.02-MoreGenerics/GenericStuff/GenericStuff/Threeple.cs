using System;        [TestMethod]
        public void TestMethod1()
        {

        }


namespace GenericStuff
{
    public class Threeple<TFirst, TSecond, TThird>
    {
        public TFirst First { get; }
        public TSecond Second { get; }
        public TThird Third { get; }
        public string Description {
            get 
            {
                //bool boolean = First == First; //  == operand function not implemented, cannot use ==
                return $"First: {First.ToString()}; Second: {Second.ToString()}; Third: ;";
            } 
        }

        public Threeple(TFirst first, TSecond second, TThird third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public static (int, string, Guid) Deconstruct<T1, T2, T3>(Threeple<T1, T2, T3> threeple)
        {
            return (threeple.First, threeple.Second, threeple.Third);
        }
    }

    public class ThreepleDescription<TFirst, TSecond, TThird>
        where TFirst : IDescription, new() // must have default constructor
    {
        public TFirst First { get; }
        public TSecond Second { get; }
        public TThird Third { get; }
        public string Description
        {
            get
            {
                return $"First: {First.Description}; Second: {Second.ToString()}; Third: ;";
            }
        }

        public ThreepleDescription(TFirst first, TSecond second, TThird third)
        {
            First = first;
            Second = second;
            Third = third;
        }
    }

    public interface Serializer<in T>
    {
        public static void Serialize(T thing)
        {

        }
       //public static T Deserializer<T>(t thinga)
       //{
       //    return default;
       //}
    }

    public interface Deserializer<out T>
    {
        public Deserialize(int d);
    }
}
