/*
 * Constants.cs
 * @author xNifty
 * 
 * Contains all of the string constants used throughout the program
 * 
 */

namespace LottoManager
{
    internal static class Constants
    {
        internal const string InvalidConnectionDetails = "Invalid username or password, please try again.";
        internal const string UnabledToContactServer = "Cannot connect to server.  Please try again.";
        internal const string MissingConnectionDetails = "Please fill out all connection details.";
        internal const string DatabaseConnected = "Database: Connected!";
        internal const string DatabaseNotConnected = "Database: Not Connected!";
        internal const string Gw2ApiConnected = "GW2 API Status: Connected";
        internal const string Gw2ApiNotConnected = "GW2 API Status: Not Connected";

        internal const string ResetListClearWarning = "Are you sure you wish to build the roll list for this " +
                                                      "session?\nDoing so will clear any currently created list.";

        internal const string ConfirmReset = "Confirm reset!";

        internal const string ListGenerationComplete = "List generation completed.";

        internal const string ErrorWithVar = "Error: {0}";
        internal const string ErrorText = "Error!";
        internal const string SuccessText = "Success!";

        internal const string WinnerListError = "There was an error with the roll history list and it could not be " +
                                                "submitted. Please submit the winner information manually through " +
                                                "the site.";
        
        internal const string AddedUpdatedUserSuccess = "Inserted/Updated {0}, with {1} rolls.";
        
        internal const string InsertedWinnerText = "Inserted {0}, with {1} rolls and items: {2}.";
        internal const string CalculatedAmount = "Calculated amount: {0}";
        internal const string CalculatedAmountSuccess = "Calculated gold amount!";

        internal const string ConfirmDatabaseClear = "!!! WARNING !!!\n" +
                                                     "Are you 100% sure you want to clear the database?\n" +
                                                     "THERE IS NO GOING BACK FROM THIS ACTION.";

        internal const string ConfirmDatabaseClearboxTitle = "ARE YOU 100% SURE?";

        internal const string ConnectToDatabaseError = "Please connect to the database.";

        // This will never change unless ANet updates their API URL
        internal const string BaseUrl = "https://api.guildwars2.com/v2/guild/";
        
        internal const string SupportForums = "https://snoring.ninja/forums";
        internal const string LottoWebPage = "https://endgame.wtf/lotto";

        // Set the text for the updates in this version text
        internal const string UpdatesInThisVersion = "New in this Version:\r\n-Internal Code Updates";

        internal const string DebugMode = "Debug Mode";
    }
}