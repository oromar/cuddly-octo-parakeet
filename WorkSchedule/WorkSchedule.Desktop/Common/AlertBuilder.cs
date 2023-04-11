using WorkSchedule.Domain;

namespace WorkSchedule.Desktop.Common
{
    public static class AlertBuilder
    {
        public static void SaveSuccessAlert()
        {
            MessageBox.Show(Strings.SuccessSaveMesssage, Strings.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void UpdateSuccessAlert()
        {
            MessageBox.Show(Strings.SuccessUpdateMessage, Strings.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void DeleteSuccessAlert()
        {
            MessageBox.Show(Strings.SuccessDeleteMessage, Strings.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ErrorMessageAlert(Exception ex)
        {
            MessageBox.Show(ex.InnerException?.Message ?? ex.Message, Strings.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ConfirmQuestionAlert()
        {
            return MessageBox.Show(Strings.AreYouSure, Strings.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void WarningMessage(string message)
        {
            MessageBox.Show(message, Strings.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ScheduleGeneratedSuccessAlert()
        {
            MessageBox.Show(Strings.SuccessGeneratedScheduleMessage, Strings.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
