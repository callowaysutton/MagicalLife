﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.DataTypes
{
    /// <summary>
    /// An 2D array that should have the basic functions of a normal array, but must be compatible with Protobuf-net.
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class ProtoArray<T> : IEnumerable
    {
        /// <summary>
        /// The width of this array.
        /// </summary>
        [ProtoBuf.ProtoMember(1)]
        public int Width { get; private set; }

        /// <summary>
        /// The height of this array.
        /// </summary>
        [ProtoBuf.ProtoMember(2)]
        public int Height { get; private set; }

        /// <summary>
        /// The actual data this array holds.
        /// </summary>
        [ProtoBuf.ProtoMember(3)]
        private T[] Data { get; set; }


        public ProtoArray(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Data = new T[width * height];
        }

        public ProtoArray()
        {

        }

        public T this[int x, int y]
        {
            get
            {
                int index = (x * this.Width) + y;
                return this.Data[index];
            }

            set
            {
                int index = (x * this.Width) + y;
                this.Data[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }
    }
}