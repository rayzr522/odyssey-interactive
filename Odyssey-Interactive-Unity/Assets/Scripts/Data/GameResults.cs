public struct GameResults {
    public int timeLeft { get; private set; }
    public int remainingHealth { get; private set; }
    public bool won { get; private set; }
    public DeathReason deathReason { get; private set; }

    public GameResults(int timeLeft, int remainingHealth, bool won, DeathReason deathReason) {
        this.timeLeft = timeLeft;
        this.remainingHealth = remainingHealth;
        this.won = won;
        this.deathReason = deathReason;
    }
}