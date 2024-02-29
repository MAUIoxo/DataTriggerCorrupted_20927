using CommunityToolkit.Mvvm.Messaging.Messages;

namespace DataTriggerCorruptedExample.ViewModels.Messages
{
    public class DisplayBottomSheetMessage : ValueChangedMessage<bool>
    {
        public DisplayBottomSheetMessage(bool value) : base(value)
        {
            
        }
    }
}
