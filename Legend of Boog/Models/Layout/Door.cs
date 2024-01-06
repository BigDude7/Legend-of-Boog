namespace Legend_of_Boog.Models.Layout
{
    public class Door
    {
        string doorType;
        bool isLocked;
        bool isCracked;
        bool isBarred;
        string doorDialog;
        int doorNum;

        public Door(bool isLocked, bool isCracked, bool isBarred)
        {
            this.isLocked = isLocked;
            this.isCracked = isCracked;
            this.isBarred = isBarred;
            doorNum = 0;
        }

        public void DecideDoorDialog()
        {
            if (isLocked == true)
            {
                doorDialog = "";
            }
        }

        public void UnlockDoor()
        {
            if (isLocked == true)
            { 
                isLocked = false;
            } else
            {
                Console.WriteLine("Door is already unlocked");
            }
        }
    }
}
