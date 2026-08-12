using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;

namespace NeoScavOpen;

public class Game1 : Core
{
    private Sprite _testButton;

    private Tilemap _containerTilemap;

    public Game1() : base("NeoScavOpen", 1280, 720, false)
    {

    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();
        TextureAtlas atlas = new TextureAtlas();
        atlas.FromFolder(GraphicsDevice, Config.DATAPATH);
        _testButton = atlas.CreateSprite("TestButton");
        Tileset tileset = new Tileset(atlas.GetRegion("GUICell"),10, 10);
        _containerTilemap = Tilemap.FromSingleTile(tileset, 4, 6);
    }

    protected override void Update(GameTime gameTime)
    {

        // Check for keyboard input and handle it.
        CheckKeyboardInput();

        base.Update(gameTime);
    }

    private void CheckKeyboardInput()
    {
        // If the space key is held down, the movement speed increases by 1.5
        if (Input.Keyboard.IsKeyDown(Keys.Space))
        {
            
        }

        // If the W or Up keys are down, move the slime up on the screen.
        if (Input.Keyboard.IsKeyDown(Keys.W) || Input.Keyboard.IsKeyDown(Keys.Up))
        {
            
        }

        // if the S or Down keys are down, move the slime down on the screen.
        if (Input.Keyboard.IsKeyDown(Keys.S) || Input.Keyboard.IsKeyDown(Keys.Down))
        {
            
        }

        // If the A or Left keys are down, move the slime left on the screen.
        if (Input.Keyboard.IsKeyDown(Keys.A) || Input.Keyboard.IsKeyDown(Keys.Left))
        {
            
        }

        // If the D or Right keys are down, move the slime right on the screen.
        if (Input.Keyboard.IsKeyDown(Keys.D) || Input.Keyboard.IsKeyDown(Keys.Right))
        {
            
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _testButton.Draw(SpriteBatch, Vector2.Zero);
        _containerTilemap.Draw(SpriteBatch);
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
