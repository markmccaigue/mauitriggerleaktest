namespace TriggerLeakTest
{
    public class HighMemoryPage : ContentPage
    {
        private byte[] _bytes = new byte[1024 * 1024 * 10];
    }
}