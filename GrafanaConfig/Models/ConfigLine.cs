﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GrafanaConfig.Models
{
    public class ConfigLine : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value == name) return;
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private int num;
        public int Num
        {
            get => num;
            set
            {
                if (value == num) return;
                num = value;
                OnPropertyChanged(nameof(Num));
            }
        }
        private int status;
        public int Status
        {
            get => status;
            set
            {
                if (value == status) return;
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        private int link;
        public int Link
        {
            get => link;
            set
            {
                if (value == link) return;
                link = value;
                OnPropertyChanged(nameof(Link));
            }
        }
        private int a;
        public int A
        {
            get => a;
            set
            {
                if (value == a) return;
                a = value;
                OnPropertyChanged(nameof(A));
            }
        }
        private int b;
        public int B
        {
            get => b;
            set
            {
                if (value == b) return;
                b = value;
                OnPropertyChanged(nameof(B));
            }
        }
        private int c;
        public int C
        {
            get => c;
            set
            {
                if (value == c) return;
                c = value;
                OnPropertyChanged(nameof(C));
            }
        }
        private int d;
        public int D
        {
            get => d;
            set
            {
                if (value == d) return;
                d = value;
                OnPropertyChanged(nameof(D));
            }
        }
        private int e;
        public int E
        {
            get => e;
            set
            {
                if (value == e) return;
                e = value;
                OnPropertyChanged(nameof(E));
            }
        }
        private int f;
        public int F
        {
            get => f;
            set
            {
                if (value == f) return;
                f = value;
                OnPropertyChanged(nameof(F));
            }
        }
        private int g;
        public int G
        {
            get => g;
            set
            {
                if (value == g) return;
                g = value;
                OnPropertyChanged(nameof(G));
            }
        }
        private int h;
        public int H
        {
            get => h;
            set
            {
                if (value == h) return;
                h = value;
                OnPropertyChanged(nameof(H));
            }
        }
        private int i;
        public int I
        {
            get => i;
            set
            {
                if (value == i) return;
                i = value;
                OnPropertyChanged(nameof(I));
            }
        }
        private int k;
        public int K
        {
            get => k;
            set
            {
                if (value == k) return;
                k = value;
                OnPropertyChanged(nameof(K));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
