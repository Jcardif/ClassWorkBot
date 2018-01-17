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
                await context.PostAsync($"You have got {dataProcess.GetNoOfTodaysUnits()} units today. The first Unit is {dataProcess.GetFirstClass().UnitName} at {dataProcess.GetFirstClass().Time.ToString()} and its venue is {dataProcess.GetFirstClass().Venue}");
            }
            else if(activity.Text.Contains("morning"))
            {
                if (dataProcess.GetMorningClass().Count == 1)
                {
                    await context.PostAsync($"Your Morning class is {dataProcess.GetMorningClass()[0].UnitName} at {dataProcess.GetMorningClass()[0].Time}. The venue for the class is {dataProcess.GetMorningClass()[0].Venue}");
                }
                else if (dataProcess.GetMorningClass().Count == 0)
                {
                    await context.PostAsync($"You have no Morning classes today. You can continue sleeping");
                }
                else if (dataProcess.GetMorningClass().Count >1)
                {
                    await context.PostAsync($"you have {dataProcess.GetMorningClass().Count} units this Morning. You are going to start with {dataProcess.GetMorningClass()[0].UnitName} at {dataProcess.GetMorningClass()[0].Time} and the venue is {dataProcess.GetMorningClass()[0].Venue}");
                }
                else
                {
                    await context.PostAsync($"I landed into a problem but I'm working on that");
                }
            }
            else if (activity.Text.Contains("afternoon"))
            {
                if (dataProcess.GetAfternoonClass().Count == 1)
                {
                    await context.PostAsync($"Your afternoon class is {dataProcess.GetAfternoonClass()[0].UnitName} at {dataProcess.GetAfternoonClass()[0].Time}. The venue for the class is {dataProcess.GetAfternoonClass()[0].Venue}");
                }
                else if(dataProcess.GetAfternoonClass().Count==0)
                {
                    await context.PostAsync($"You have no afternoon classes today. Enjoy your siesta");
                }
                else if (dataProcess.GetAfternoonClass().Count > 1)
                {
                    await context.PostAsync($"you have {dataProcess.GetAfternoonClass().Count} this afternoon. You are going to start with {dataProcess.GetAfternoonClass()[0].UnitName} at {dataProcess.GetAfternoonClass()[0].Time} and the venue is {dataProcess.GetAfternoonClass()[0].Venue}");
                }
                else
                {
                    await context.PostAsync($"I landed into a problem but I'm working on that");
                }
            }
            else if(activity.Text.StartsWith("what time"))
            {
                if (dataProcess.GetClassTime("physical electronics").Count == 0)
                {
                    await context.PostAsync($"You have no such class today");
                }
                else if (dataProcess.GetClassTime("physical electronics").Count == 2)
                {
                    await context.PostAsync($"hghhgh");
                }
            }
            context.Wait(ActivityReceivedAsync);
        }
    }
}