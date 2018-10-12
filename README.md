# tmapgen
This program converts tilemaps made with Tiled, a cross-platform donationware tilemap editor, into the tmap listings 
used in Fighters Anthology's MM files.

## Usage
This section is a work in progress.

### Requirements
1. A complete ground texture tile set extracted from Fighters Anthology (FA). An example can be found in APA.ZIP
2. Tiled (https://www.mapeditor.org/)
3. Patience and creativity when translating real world maps into the blocky tiles that FA uses.
4. At least Microsoft .NET Framework Version 4.6 (https://www.microsoft.com/net/download/dotnet-framework-runtime/net462)

### Procedure

#### Creating a new tile set

1. Open Tiled and create a new tileset, using ``New > New Tile Set``
2. In the New Tileset Dialog, give the tileset a name and ensure that the Type is selected as "Collection of Images"
3. Choose a location to save the tile set.
4. Add the tile images to the tile set using the ``Tileset > Add Tiles`` dropdown menu and menu item. This can also be achieved by clicking the `+` (plus) icon in the icon bar.
5. Add the desired tiles to the tile set in the new file selector dialog.
6. Save the tile set.

#### Adding tiles to the map

1. Create a new map by selecting  ``File > New > New Map (Ctrl+N)`` from the dropdown menu.
2. In the ``New Map - Tiled`` dialog, ensure that the Tile Layer Format is shown as ``CSV``, the map size should be a maximum of 64 tiles wide and 64 tiles tall. Ensure that the map rendering order is set to ``Left Up`` and the tile size is 256 x 256 pixels.
3. Select a location to save the tilemap.
4. Specify a tileset to use for the map by clicking the dropdown menu under ``Map > Add External Tileset``
5. Select the tileset you wish to use for the map.
6. Add tiles to the map by selecting them from the Tilesets drawer and adding them to the map. Rotate the tiles by clicking the rotation icons on the icon bar at the top of the screen as needed.
7. Save the map as a .TMX file in a convenient location.

#### Generating the ``tmap`` entries for the ``MM`` map 

1. In Windows Explorer, drag the .TMX file on to ``tmapgen.exe`` or execute tmapgen.exe from the Command Prompt with the .TMX file as the only argument.
2. Open the resulting file named after the .TMX file with the extension .TXT (ex. Map.TMX.TXT) in your favorite text editor. You should see a file containing rows of ``tmap <x> <y> <tile> <rot>`` where ``x`` and ``y`` are the x-axis and y-axis coordinates of the tile and ``tile`` and ``rot`` are the tile number and rotation angle for the tile. Copy these lines into an existing MM file or template and replace the existing tmap entries.
3. **Caveat** The .MM file must have the same file name as a terrain tile set and T2 file that exists already within one of the FA libraries. In order to create an entirely standalone map, you need to have the complete set of tiles, MM, and T2 files.

#### Testing the new ``MM`` map

1. Copy the ``.MM`` file to the Fighters Anthology root directory and test it using the Pro Mission Creator.
