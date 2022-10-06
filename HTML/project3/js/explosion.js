function loadSpriteSheet()
{
    //the 16 animation frames in each row are 64x64 pixels
    //we are using the second row
    //http://pixijs.download/release/docs/PIXI. BaseTexture.html
    let spriteSheet = PIXI.BaseTexture.from("images/explosion.png");
    let width = 70;
    let height = 64;
    let numFrames = 10;
    let textures = [];
    for (let i=0; i<numFrames; i++)
    {
        //http://pixijs.download/release/docs/PIXI. Texture.html
        let frame = new PIXI.Texture(spriteSheet, new PIXI.Rectangle(i*width, 70, width, height));
        textures.push(frame);
    }

    return textures;
}   

//create the explosions
function createExplosion(x, y, frameWidth, frameHeight)
{
    let w2 = frameWidth / 2;
    let h2 = frameHeight / 2;
    let expl = new PIXI.AnimatedSprite(explosionTextures);
    expl.x = x - w2;
    expl.y = y - h2;
    expl.animationSpeed = 1 / 4;
    expl.loop = false;
    expl.onComplete = e => gameScene.removeChild(expl);
    explosions.push(expl);
    gameScene.addChild(expl);
    expl.play();
}