using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace IsartPolarium
{
	/// <summary>
	/// Scene state.Indicate the state of the actual Scene
	/// </summary>
	public enum SceneState
	{
		SLEEP,
		UPDATE,
		DRAW,
		UPDATEDRAW
	}

	public abstract class AScene
	{
		public SceneManager sceneManager;
		public SceneState sceneState;

		List<AEntity> _LEntities;
		List<AEntity> _LEntitiesToAdd;
		List<AEntity> _LEntitiesToRemove;

		protected AScene(SceneManager _SM)
		{
			sceneManager = _SM;
		}

		/// <summary>
		/// Initialize automatically the scene
		/// </summary>
		public virtual void Initialize()
		{
			_LEntities = new List<AEntity> ();
			_LEntitiesToAdd = new List<AEntity> ();
			_LEntitiesToRemove = new List<AEntity> ();
			sceneState = SceneState.UPDATEDRAW;
		}
			
		public virtual void LoadContent()
		{
			
		}

		/// <summary>
		/// Update at the specified gameTime.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public virtual void Update(GameTime gameTime)
		{
			foreach (AEntity entity in _LEntities)
				entity.Update (gameTime);
			UpdateEntities ();
		}

		public virtual void Draw(GameTime gameTime)
		{
			foreach (AEntity entity in _LEntities)
				entity.Draw (gameTime);
		}

		/// <summary>
		/// You HAVE TO add the entity to your scene to automatically update the entity
		/// </summary>
		/// <returns><c>true</c>, if entity was added, <c>false</c> otherwise.</returns>
		/// <param name="entity">Entity.</param>
		public bool AddEntity(AEntity entity)
		{
			if (_LEntities.Contains (entity) || _LEntitiesToAdd.Contains (entity))
				return false;
			entity.Initialize ();
			entity.LoadContent ();
			_LEntitiesToAdd.Add (entity);
			return true;
		}

		/// <summary>
		/// Removes the entity from the update list.
		/// </summary>
		/// <param name="entity">Entity.</param>
		public void RemoveEntity(AEntity entity)
		{
			if (!_LEntitiesToRemove.Contains (entity) && _LEntities.Contains(entity))
				_LEntitiesToRemove.Add (entity);
		}

		void UpdateEntities()
		{
			foreach (AEntity entity in _LEntitiesToAdd)
				_LEntities.Add (entity);
			foreach (AEntity entity in _LEntitiesToRemove)
				_LEntities.Remove (entity);
			_LEntitiesToAdd.Clear ();
			_LEntitiesToRemove.Clear ();
		}

		/// <summary>
		/// Gets the entities number.
		/// </summary>
		/// <returns>The entities nbr.</returns>
		public int GetEntitiesNbr()
		{
			return _LEntities.Count;
		}

		/// <summary>
		/// Find and get an entity
		/// </summary>
		/// <returns>The entity by name.</returns>
		/// <param name="name">Name.</param>
		public AEntity GetEntityByName(string name)
		{
			foreach (AEntity entity in _LEntities)
				if (entity.name == name)
					return entity;
			return null;
		}

		public List<AEntity> Intersects(Rectangle re)
		{
			List<AEntity> LAE = new List<AEntity> ();
			foreach (AEntity entity in _LEntities)
				if (re.Intersects(entity.hitBox))
					LAE.Add(entity);
			return LAE;
		}
		public List<AEntity> Intersects(AEntity ae)
		{
			return Intersects (ae.hitBox);
		}
		public List<AEntity> Intersects()
		{
			return Intersects (AdvancedMouse.hitBox);
		}
	}
}
