using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer 
{
    public class ByteBuffer
    {
        private List<byte> Buff;
        private byte[] readBuff;
        private int readPos;
        private bool buffUpdated = true;

        public ByteBuffer()
        {
            Buff = new List<byte>();
            readPos = 0;
        }

        public int GetReadPos()
        {
            return readPos;
        }

        public byte[] ToArray()
        {
            return Buff.ToArray();
        }

        public int Count()
        {
            return Buff.Count();
        }

        public int Length()
        {
            return Count() - readPos;
        }

        public Clear(){
            Buff.Clear();
            buffUpdated = true;
        }

        public void WriteByte(byte[] input)
        {
            Buff.AddRange(input);
            buffUpdated = true;
        }

        public coid WriteLong(int input){
            Buff.AddRange(BitConverter.GetBytes(input));
            buffUpdated = true;
        }

        public void WriteInteger(int input)
        {
            Buff.AddRange(BitConverter.GetBytes(input));
            buffUpdated = true;
        }

        public void WriteFloat(float input){
            Buff.AddRange(BitConverter.GetBytes(input));
            buffUpdated = true;
        }

        public void WriteBool(bool input){
            Buff.AddRange(BitConverter.GetBytes(input));
            buffUpdated = true;
        }
        public void WriteString(string input){
            Buff.AddRange(BitConverter.GetBytes(input.Length));
            Buff.AddRange(Encoding.UTF8.GetBytes(input));
            buffUpdated = true;
        }
    }
}