namespace Http_Trigger_Github.Model
{
    public class SlackMessage
    {
        public string? text {  get; set; }

        public SlackMessage(string text)
        { 
            this.text = text;
        }
    }
}
