using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace NeoScavOpen;

public class Game1 : Core
{
    private Sprite _testButton;

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
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _testButton.Draw(SpriteBatch, Vector2.Zero);
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
