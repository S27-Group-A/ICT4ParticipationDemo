// <copyright file="RFIDManager.cs" company="Ict4Rails">
//      Copyright (c) ICT4Rails. All rights reserved.
// </copyright>
// <author>Pim Janissen</author>
// <author>Jeroen Janssen</author>
namespace S21M_RailB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Phidgets;
    using Phidgets.Events;

    /// <summary>
    /// RFIDManager class, for storing RFID information in an object.
    /// </summary>
    public class RFIDManager
    {
        #region Fields
        /// <summary>
        /// An instance of the RFID class.
        /// </summary>
        private RFID rfid;
        #endregion Fields

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RFIDManager"/> class.
        /// </summary>
        public RFIDManager()
        {
            this.rfid = new RFID();
            this.rfid.Attach += this.RFID_Attach;
            this.rfid.Detach += this.RFID_Detach;
            this.rfid.Tag += this.RFID_Tag;

            this.Open();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// An event which is thrown when a RFID reader is attached.
        /// </summary>
        public event AttachEventHandler Attached;

        /// <summary>
        /// An event which is thrown when a RFID reader is detached.
        /// </summary>
        public event DetachEventHandler Detached;

        /// <summary>
        /// An event which is thrown when a tag is scanned by a RFID reader.
        /// </summary>
        public event TagEventHandler DataReceived;

        /// <summary>
        /// Opens a new RFID connection.
        /// </summary>
        public void Open()
        {
            //this.rfid.open();
        }

        /// <summary>
        /// Closes the current RFID connection.
        /// </summary>
        public void Close()
        {
            if (this.rfid.Attached)
            {
                this.rfid.Antenna = false;
                this.rfid.LED = false;
            }

            this.rfid.close();
        }

        /// <summary>
        /// An event handler of an event that is thrown when an RFID is attached.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void RFID_Attach(object sender, AttachEventArgs e)
        {
            this.Attached(sender, e);

            // Turn on the antenna and the led to show everything is working.
            this.rfid.Antenna = true;
            this.rfid.LED = true;
        }

        /// <summary>
        /// An event handler of an event that is thrown when an RFID is detached.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void RFID_Detach(object sender, DetachEventArgs e)
        {
            this.Detached(sender, e);
        }

        /// <summary>
        /// An event handler of an event that is thrown when a tag comes in the scan range of the scanner.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        public void RFID_Tag(object sender, TagEventArgs e)
        {
            this.DataReceived(sender, e);
        }
        #endregion Methods
    }
}
