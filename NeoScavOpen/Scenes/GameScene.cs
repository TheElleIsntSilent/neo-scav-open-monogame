using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;
using MonoGameLibrary.Scenes;

namespace NeoScavOpen.Scenes;

public class GameScene : Scene
{
        
    // Defines the slime animated sprite.
    private Sprite _testButton;

    // Defines the tilemap to draw.
    private Tilemap _tilemap;

    // Defines the bounds of the room that the slime and bat are contained within.
    private Rectangle _roomBounds;

    // The SpriteFont Description used to draw text
    private SpriteFont _font;
        
    // Tracks the position of the bat.
    private Vector2 _buttonPosition;
    
    public override void Initialize()
    {
        // LoadContent is called during base.Initialize().
        base.Initialize();

        // During the game scene, we want to disable exit on escape. Instead,
        // the escape key will be used to return back to the title screen
        Core.ExitOnEscape = false;

        Rectangle screenBounds = Core.GraphicsDevice.PresentationParameters.Bounds;

        _roomBounds = new Rectangle(
            (int)_tilemap.TileWidth,
            (int)_tilemap.TileHeight,
            screenBounds.Width - (int)_tilemap.TileWidth * 2,
            screenBounds.Height - (int)_tilemap.TileHeight * 2
        );

        // Initial slime position will be the center tile of the tile map.
        int centerRow = _tilemap.Rows / 2;
        int centerColumn = _tilemap.Columns / 2;
        _buttonPosition = new Vector2(centerColumn * _tilemap.TileWidth, centerRow * _tilemap.TileHeight);
    }

    public override void LoadContent()
    {
        // Create the texture atlas from the XML configuration file.
        TextureAtlas atlas = TextureAtlas.FromFile(Core.Content, "images/atlas-definition.xml");

        // Create the slime animated sprite from the atlas.
        _testButton = atlas.CreateSprite("TestButton");
        _testButton.Scale = new Vector2(4.0f, 4.0f);

        // Create the tilemap from the XML configuration file.
        _tilemap = Tilemap.FromFile(Content, "images/tilemap-definition.xml");
        _tilemap.Scale = new Vector2(4.0f, 4.0f);

        // Load the font.
        _font = Core.Content.Load<SpriteFont>("Fonts/DefaultFont");
    }

public override void Update(GameTime gameTime)
{
    // Update the slime animated sprite.
    //_testButton.Update(gameTime);     No animation for button (for now)

    // Check for keyboard input and handle it.
    CheckKeyboardInput();
    

}

private void CheckKeyboardInput()
{
    // Get a reference to the keyboard inof
    KeyboardInfo keyboard = Core.Input.Keyboard;

    // If the escape key is pressed, return to the title screen.
    if (Core.Input.Keyboard.WasKeyJustPressed(Keys.Escape))
    {
        Core.ChangeScene(new TitleScene());
    }
}

public override void Draw(GameTime gameTime)
{
    // Clear the back buffer.
    Core.GraphicsDevice.Clear(Color.CornflowerBlue);

    // Begin the sprite batch to prepare for rendering.
    Core.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

    // Draw the tilemap
    _tilemap.Draw(Core.SpriteBatch);

    // Always end the sprite batch when finished.
    Core.SpriteBatch.End();
}

}