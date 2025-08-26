param(
    [int]$IntervalSeconds = 5,
    [int]$DurationMinutes = 1,
    [string]$OutputPath = "C:\Monitoring"
)
# Ensure output directory exists
if (!(Test-Path $OutputPath)) {
    New-Item -ItemType Directory -Path $OutputPath -Force
}
$EndTime = (Get-Date).AddMinutes($DurationMinutes)
$LogFile = Join-Path $OutputPath "performance_$(Get-Date -Format 'yyyyMMdd_HHmmss').log"
Write-Host "Starting monitoring... Output: $LogFile"
Write-Host "Duration: $DurationMinutes minutes, Interval: $IntervalSeconds seconds"
while ((Get-Date) -lt $EndTime) {
    $timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
    # System metrics
    $cpu = (Get-Counter "\Processor(_Total)\% Processor Time").CounterSamples.CookedValue
    $memory = (Get-Counter "\Memory\Available MBytes").CounterSamples.CookedValue
    $diskQueue = (Get-Counter "\PhysicalDisk(_Total)\Current Disk Queue Length").CounterSamples.CookedValue
    
    $logEntry = "$timestamp, CPU:$([math]::Round($cpu, 2))%, Memory:$([math]::Round($memory, 2)) MB, DiskQueue:$([math]::Round($diskQueue, 2))"
    Add-Content -Path $LogFile -Value $logEntry
    Write-Host $logEntry
    Start-Sleep -Seconds $IntervalSeconds
}
Write-Host "Monitoring completed. Log saved to: $LogFile"
