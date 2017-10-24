using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using ClassWorkData;

namespace ClassWorkBot.Dialogs
{
    [Serializable]
    public class SimpleDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ActivityReceivedAsync);
        }

        private async Task ActivityReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            DataProcess dataProcess = new DataProcess();
            if(activity.Text.Contains("how is today"))
            {
                await context.PostAsync($"you have got {dataProcess.GetFirstClass().UnitName}");
            }
            context.Wait(ActivityReceivedAsync);
        }
    }
}