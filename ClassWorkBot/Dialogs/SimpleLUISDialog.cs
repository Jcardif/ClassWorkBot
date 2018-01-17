using System;
using System.Threading.Tasks;
using ClassWorkData;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace ClassWorkBot.Dialogs

{
    //[LuisModel("a20519fc-337a-4428-aff4-58996d5cc7fd-337a-4428-aff4-58996d5cc7fd", "f55347eb806d489d9b047cce4cef220")]
    [Serializable]
    public class SimpleLUISDialog : LuisDialog<object>
    {
        public static DataProcess dataprocess = new DataProcess();

        [LuisIntent("TeamCount")]
        public async Task GetTeamCount(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"There are {dataprocess.GetNoOfTodaysUnits()} teams.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I have no idea what you are talking about.");
            context.Wait(MessageReceived);
        }
    }
}