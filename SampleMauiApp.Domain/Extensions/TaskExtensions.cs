namespace SampleMauiApp.Domain.Extensions
{
    public static class TaskExtensions
    {
        public async static void Await(this Task task, Action? completedCallback = null, Action<Exception>? errorCallback = null)
        {
            try
            {
                await task;
                completedCallback?.Invoke();
            }
            catch (Exception ex)
            {
                errorCallback?.Invoke(ex);
            }
        }
    }
}
