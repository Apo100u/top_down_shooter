using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    public PlayerInput Input { get { return input; } }

    [SerializeField] private PlayerMovement movement;
    public PlayerMovement Movement { get { return movement; } }

    [SerializeField] private PlayerCombat combat;
    public PlayerCombat Combat { get { return combat; } }

    [SerializeField] private Health health;
    public Health Health { get { return health; } }

    [SerializeField] private HUD hud;
    public HUD Hud { get { return hud; } }

    private int score = 0;
    private WaitForSeconds waitForSpawn = new WaitForSeconds(2f);

    private void Start()
    {
        health.SetAsMax();
        movement.Init(this);
        combat.Init(this);

        health.OnHealthChanged += OnHealthChanged;
        health.OnAllHealthLost += OnAllHealthLost;
    }

    private void OnHealthChanged()
    {
        hud.UpdateHealth(health.CurrentHealth / health.MaxHealth);
    }

    private void OnAllHealthLost()
    {
        StartCoroutine(hud.Fade(1f));
        StartCoroutine(RespawnDelayed());
    }

    private IEnumerator RespawnDelayed()
    {
        yield return waitForSpawn;
        transform.position = Vector3.zero;
        health.SetAsMax();

        hud.HideFade();
    }

    private void Update()
    {
        input.OnUpdate();
        movement.OnUpdate();
        combat.OnUpdate();
    }

    public void AddScore()
    {
        score++;
        hud.UpdateScore(score);
    }
}