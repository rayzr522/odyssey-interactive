public struct GameResults {
    public int secondsLeft { get; private set; }
    public int remainingHealth { get; private set; }
    public bool won { get; private set; }
    public DeathReason deathReason { get; private set; }

    public GameResults(int secondsLeft, int remainingHealth, bool won, DeathReason deathReason) {
        this.secondsLeft = secondsLeft;
        this.remainingHealth = remainingHealth;
        this.won = won;
        this.deathReason = deathReason;
    }
}