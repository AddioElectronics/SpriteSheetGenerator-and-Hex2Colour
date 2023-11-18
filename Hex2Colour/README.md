# Hex2Colour
---
#### `V1.0.0`

A simple tool for converting Hex values into code and extracting color hex values from text. Paste your hex values and click 'Convert,' or input text from a webpage or URL and click 'Harvest.' Customize the output with the ability to define custom naming formats. For array output, simply add a name on the line above the color value. 

## Features
- Hex2Colour
    - Converts HEX value to code
    - Swaps endianess (Keep alpha MSB)
    - Generate array code
    - Add support for any Language/API via JSON file
    - Variable naming and comments
    - Custom naming format
    - Canadian or American spelling
    - Auto-Clipboard
    - Remembers settings from last session
    - Save and load settings files

- Colour Harvestor (Tool)
    - Parses hex values from strings
    - Downloads text from static webpages
    - Custom Regex Pattern
    - Automatically add colours to Hex2Colour

## Images
<details closed>
  <summary>Hex2Colour Examples</summary>
    <IMG src="https://github.com/AddioElectronics/SpriteSheetGenerator-and-Hex2Colour/blob/main/Hex2Colour/Images/hex2col.png?raw=true"/>
</details>

<details closed>
  <summary>Colour Harvestor Example</summary>
    <IMG src="https://github.com/AddioElectronics/SpriteSheetGenerator-and-Hex2Colour/blob/main/Hex2Colour/Images/colourharvestor.png?raw=true"/>
</details>

## Usage
`C GDI with endianess swapping used for examples`
1. Open the settings and pick your `Language/Api`.
    - For GDI you will want to check `Reverse Endianess` and `Alpha MSB`
2. Add colour hex values to the input textbox.
3. Click 'Convert' or 'Append'

### Adding new Language/API

1. Open `langs.json` located next to the executable.
2. Add new JSON object with these values...
    - `name` The text in the combo box
    - `format` The format for a single variable.
        - `{0}` variable name
        - `{1}` colour value
    - `arrayStart` The format for the start of an array
        - `{0}` array name
    - `arrayItem` The format for the array item
        - `{0}` colour value
    - `arrayEnd` The format for the end of the array
    - `lang` *Currently Unused*
    - `lib` *Currently Unused*


### Output indiviudual variables

Add a colour per line

----

    (Input)
    0xFF0000
    #FF0000
    
    FF000000

    (Output)
    const COLORREF colour0 = 0x0000FF;
    const COLORREF colour1 = 0x0000FF;
    
    const COLORREF colour2 = 0xFF000000;


### Output As Array

Start an array by adding a name on the line above the first value.
To stop leave the line empty.

----

    (Input)
    ArrayName
    FF0000
    FF0000
    
    00FF00
    
    Array2
    0000FF
    0000FF
    
    (Output)
    const COLORREF colour0 = 0x00FF00;

    const COLORREF ArrayName[] = 
    {
    	0x0000FF,
    	0x0000FF,
    };
    
    const COLORREF Array2[] = 
    {
    	0xFF0000,
    	0xFF0000,
    };
    
### Names and Comments

Write a name directly after the colour, and a comment directly after the name.
For arrays, add text after the colour to add a comment.

----
    
    (Input)
    FF0000 name This will add a comment
    
    RgbArray
    FF0000 Red
    00FF00 Green
    0000FF Blue
    
    (Output)
    const COLORREF name = 0x0000FF; //This will add a comment
    
    const COLORREF RgbArray[] = 
    {
	    0x0000FF,	//Red
	    0x00FF00,	//Green
	    0xFF0000,	//Blue
    };


    
### Name Format

Add a C# style format string to the `Name Format` textbox.

----

**Formatters**
- `{0}` Name or index when name is null
- `{1}` Index when name is not null
- `{2}` Colour value before endianess swap
- `{3}` True colour value (After endianess swap)

 ----

    (Textbox)
    g_col{0}
    
    (Input)
    FF0000
    FF0000 Name
    FF0000 %Red Format name
    
    (Output)
    const COLORREF g_col0 = 0x0000FF;
    const COLORREF Name = 0x0000FF;
    const COLORREF g_colRed = 0x0000FF; //Format name
    
    (Textbox)
    g_col{0}{1}_0x{2:X6}
    
    (Input)
    FF0000 Red
    00FF00 Green
    0000FF Blue
    
    (Output)
    const COLORREF g_colRed0_0xFF0000 = 0x0000FF;
    const COLORREF g_colGreen1_0x00FF00 = 0x00FF00;
    const COLORREF g_colBlue2_0x0000FF = 0xFF0000;


### Symbols

- `%` Forces name to format.
- `!` Stops name from being formatted. (Only used when `Always Format Name` setting enabled)
- `#` For adding comment but not a name

## License

- [GNU GPLv3][License]
## Author

- Author : Addio
- Website : www.Addio.io

[License]:https://github.com/AddioElectronics/SpriteSheetGenerator-and-Hex2Colour/blob/main/LICENSE

