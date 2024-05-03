namespace Inlog.Desafio.Backend.Application.Configuration.Events
{
    public class ResultEvent : IEvent
    {
        public bool Success { get; }
        public object Data { get; }

        public ResultEvent()
        { }

        public ResultEvent(bool _sucess, object _data)
        {
            Success = _sucess;
            Data = _data;
        }
    }
}