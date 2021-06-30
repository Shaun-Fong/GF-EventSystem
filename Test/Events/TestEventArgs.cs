namespace GF.EventSystem.Test
{
    public class TestEventArgs : GameEventArgs
    {

        public static readonly int EventId = typeof(TestEventArgs).GetHashCode();

        public override int Id => EventId;

        public string TestStr;

        public static TestEventArgs Create(string str)
        {
            TestEventArgs args = new TestEventArgs();
            args.TestStr = str;
            return args;
        }

        public override void Clear()
        {
            TestStr = null;
        }

    }

}
