﻿//============================================================================
// BDInfo - Blu-ray Video and Audio Analysis Tool
// Copyright © 2010 Cinema Squid
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//=============================================================================

using System;
using System.Collections.Generic;
using System.Text;

using BDInfo.IO;

namespace BDInfo
{
    class DiscFileInfo : IFileInfo
    {
        private readonly DiscUtils.DiscFileInfo _impl;
        public string Name => _impl.Name;

        public string FullName => _impl.FullName;

        public string Extension => _impl.Extension;

        public long Length => _impl.Length;

        public bool IsDir => _impl.Attributes.HasFlag(System.IO.FileAttributes.Directory);

        public DiscFileInfo(DiscUtils.DiscFileInfo impl)
        {
            _impl = impl;
        }

        public System.IO.Stream OpenRead()
        {
            return _impl.OpenRead();
        }

        public System.IO.StreamReader OpenText()
        {
            return _impl.OpenText();
        }
    }
}