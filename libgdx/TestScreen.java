package com.tibba.urush.screens;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Screen;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.physics.box2d.World;
import com.badlogic.gdx.utils.viewport.ExtendViewport;
import com.tibba.urush.actors.*;
import com.tibba.urush.tools.B2DVars;
import com.tibba.urush.tools.ContactEngine;

public class TestScreen implements Screen {
	
	private int MIN_WIDTH = 960;
	private int MAX_WIDTH = 960;
	private int MIN_HEIGHT = 540;
	private int MAX_HEIGHT = 768;	 
	
	private OrthographicCamera camera;
	private ExtendViewport viewport;
	private SpriteBatch spriteBatch;
		
	private World world;
	private Background bkg;
	
	@Override
	public void show() {       
		camera = new OrthographicCamera();
	    viewport = new ExtendViewport(MIN_WIDTH, MIN_HEIGHT, MAX_WIDTH, MAX_HEIGHT,camera);
	    viewport.apply();		
	    spriteBatch = new SpriteBatch();
		world = new World(new Vector2(0,-98 * B2DVars.PPM), true);		
		world.setContactListener(new ContactEngine());
		bkg = new Background();		
	}

	@Override
	public void render(float delta) {
		Gdx.gl.glClearColor(1, 0, 0, 1);
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);	
		camera.update();
		spriteBatch.setProjectionMatrix(camera.combined);
		world.step(0.002f, 1, 1);
		spriteBatch.begin();
        bkg.draw(spriteBatch);
        spriteBatch.end();		
	}	

	@Override
	public void resize(int width, int height) {   
		camera.position.set(MAX_WIDTH / 2, MAX_HEIGHT / 2, 0);
		viewport.update(width,height);
	}		

	@Override
	public void pause() {
		
	}

	@Override
	public void resume() {
		
	}

	@Override
	public void hide() {
		
	}

	@Override
	public void dispose() {
	}	
	
	public World getWorld() {
		return world;
	}

	public void setWorld(World world) {
		this.world = world;
	}
}