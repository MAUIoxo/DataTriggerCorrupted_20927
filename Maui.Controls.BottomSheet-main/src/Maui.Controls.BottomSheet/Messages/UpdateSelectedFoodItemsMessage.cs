using CommunityToolkit.Mvvm.Messaging.Messages;

namespace XGENO.Maui.Controls.Messages
{
    public class BottomSheetClosedMessage : ValueChangedMessage<bool>
    {
        public BottomSheetClosedMessage(bool value) : base(value)
        {
            
        }
    }
}
