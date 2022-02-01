using System;

namespace Chatter;

public class Message
{
    public DateTime Timestamp { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }

    public override string ToString()
    {
        return $"[{Timestamp.ToLongTimeString()}] {Name}: {Content}";
    }
}
