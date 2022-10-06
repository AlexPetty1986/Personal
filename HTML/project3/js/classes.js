//ship class
class Ship extends PIXI.Sprite
{
    constructor(x = 0, y = 0, url)
    {
        super(app.loader.resources[url].texture);
        this.anchor.set(0.5, 0.5);
        this.scale.set(0.1);
        this.x = x;
        this.y = y;
    }
}

//alien class
class Alien extends PIXI.Sprite
{ 
    constructor(x=0, y=0, url)
    {
        super(app.loader.resources[url].texture);
        this.x = x; 
        this.y = y; 
        // variables 
        this.fwd = getRandomUnitVector(); 
        this.speed = 50 + round; 
        this.isAlive = true;
    }

    activate(){}

    //alien movement
    move (dt=1/60)
    {
        this.x += this.fwd.x * this.speed * dt; 
        this.y += this.fwd.y * this.speed * dt;
    }

    //bounce off wall
    reflectX()
    {
        this.fwd.x *= -1;
    }

    //bounce off wall
    reflectY()
    {
        this.fwd.y *= -1;
    }

    //wrap screen
    wrapX()
    {
        if(this.x > sceneWidth)
        {
            this.x = 0;
        }

        else if(this.x < 0)
        {
            this.x = sceneWidth;
        }
    }

    //wrap screen
    wrapY()
    {
        if(this.y > sceneHeight)
        {
            this.y = 0;
        }

        else if(this.y < 0)
        {
            this.y = sceneHeight;
        }
    }

    //allows for targeting
    seek(dt)
    {
        let tar = this.target;
        let amt = dt * this.speed;
        this.x = cosineInterpolate(this.x, tar.x, amt);
        this.y =  cosineInterpolate(this.y, tar.y, amt);
    }
}

//Alien Seekers
class AlienSeek extends Alien
{
    activate(target)
    {
        this.target = target;
    }

    move(dt)
    {
        super.seek(dt);
    }
}

//Alien Wrappers
class AlienWrap extends Alien
{
    reflectX()
    {
        super.wrapX();
    }

    reflectY()
    {
        super.wrapY();
    }
}

//Ship bullets
class Bullet extends PIXI.Graphics
{
    constructor(color=0xFF0000, x=0, y=0)
    {
        super();
        this.beginFill(color);
        this.drawRect(-2,-3,4,6);
        this.endFill();
        this.x = x;
        this.y = y;
        // variables
        this.fwd = {x:0,y:-1};
        this.speed = 400;
        this.isAlive = true;
        Object.seal(this);
    }

    move (dt=1/60)
    {
        this.x += this.fwd.x * this.speed * dt;
        this.y += this.fwd.y * this.speed * dt;
    }

    backShot(dt=1/60)
    {
        this.y -= this.fwd.y * this.speed * dt;
    }
}

//Back bullets for ship 3
class BackBullet extends Bullet
{
    move(dt)
    {
        super.backShot(dt);
    }
}