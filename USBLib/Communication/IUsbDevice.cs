﻿using System;

namespace UCIS.USBLib.Communication {
	public interface IUsbDevice : IUsbInterface, IDisposable {
		new Byte Configuration { get; set; }
		void ClaimInterface(int interfaceID);
		void ReleaseInterface(int interfaceID);
		void ResetDevice();

		IUsbDeviceRegistry Registry { get; }
	}
	public interface IUsbInterface : IDisposable {
		Byte Configuration { get; }
		void Close();

		int GetDescriptor(byte descriptorType, byte index, short langId, Byte[] buffer, int offset, int length);

		int PipeTransfer(Byte endpoint, Byte[] buffer, int offset, int length);
		IAsyncResult BeginPipeTransfer(Byte endpoint, Byte[] buffer, int offset, int length, AsyncCallback callback, Object state);
		int EndPipeTransfer(IAsyncResult asyncResult);
		void PipeReset(Byte endpoint);
		void PipeAbort(Byte endpoint);
		int ControlTransfer(UsbControlRequestType requestType, byte request, short value, short index, Byte[] buffer, int offset, int length);
		IAsyncResult BeginControlTransfer(UsbControlRequestType requestType, byte request, short value, short index, Byte[] buffer, int offset, int length, AsyncCallback callback, Object state);
		int EndControlTransfer(IAsyncResult asyncResult);

		UsbPipeStream GetPipeStream(Byte endpoint);
	}
}
