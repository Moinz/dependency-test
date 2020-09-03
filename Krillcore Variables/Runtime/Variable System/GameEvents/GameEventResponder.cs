using UnityEngine;
using UnityEngine.Events;

/*public class GameEventResponder : MonoBehaviour, IGameEventListener
{
	[SerializeField]
	private GameEvent _event;

	public UnityEvent _simpleResponse;

	public UnityEventBool _boolResponse;
	public BoolReference _boolArgument;

	private void OnEnable()
	{
		_event.RegisterListener(this);
	}

	private void OnDisable()
	{
		_event.UnregisterListener(this);
	}

	public virtual void OnGameEvent(GameEvent caller)
	{
		if (_simpleResponse != null)
			_simpleResponse.Invoke();

		if (_boolResponse != null)
			_boolResponse.Invoke(_boolArgument.Value);
	}
}*/
