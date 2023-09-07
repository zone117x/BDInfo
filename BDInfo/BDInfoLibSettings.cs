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

namespace BDInfoLib;

internal class BDInfoLibSettingsBase
{
    internal bool ExtendedStreamDiagnostics { get; set; } = true;
    
    public bool EnableSSIF { get; set; } = true;
    
    public bool FilterLoopingPlaylists { get; set; } = true;
    
    public bool FilterShortPlaylists { get; set; } = true;
    
    public int FilterShortPlaylistsValue { get; set; } = 20;
    
    public bool KeepStreamOrder { get; set; } = true;
}

public static class BDInfoLibSettings
{
    private const string FileName = "BDInfoLibSettings.json";
    private static BDInfoLibSettingsBase _libSettings;

    public static void Load()
    {
        Load(false);
    }

    public static void Load(bool forceLoad) 
    {
        if (!forceLoad && _libSettings != null) return;
        _libSettings = new();
    }

    public static void Save()
    {
        // removed
    }

    public static void ResetToDefault()
    {
        _libSettings = new BDInfoLibSettingsBase();
    }

    public static void RevertChanges()
    {
        Load(true);
    }

    public static bool ExtendedStreamDiagnostics
    {
        get => _libSettings.ExtendedStreamDiagnostics;

        set => _libSettings.ExtendedStreamDiagnostics = value;
    }

    public static bool EnableSSIF
    {
        get => _libSettings.EnableSSIF;

        set => _libSettings.EnableSSIF = value;
    }

    public static bool FilterLoopingPlaylists
    {
        get => _libSettings.FilterLoopingPlaylists;

        set => _libSettings.FilterLoopingPlaylists = value;
    }

    public static bool FilterShortPlaylists
    {
        get => _libSettings.FilterShortPlaylists;

        set => _libSettings.FilterShortPlaylists = value;
    }

    public static int FilterShortPlaylistsValue
    {
        get => _libSettings.FilterShortPlaylistsValue;

        set => _libSettings.FilterShortPlaylistsValue = value;
    }

    public static bool KeepStreamOrder
    {
        get => _libSettings.KeepStreamOrder;

        set => _libSettings.KeepStreamOrder = value;
    }
}