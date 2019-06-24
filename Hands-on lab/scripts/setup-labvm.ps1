param($labFilesUri="")

# Install SSMS
iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1')) 
choco install sql-server-management-studio -y

# Download Lab Files
$labFilesFolder = "C:\LabFiles"
if ([string]::IsNullOrEmpty($labFilesUri) -eq $false)
{
    Write-Host "Make sure folder exists"
    if ((Test-Path $labFilesFolder) -eq $false)
    {
        New-Item -Path $labFilesFolder -ItemType directory
    }

    Write-Host "Parse file name"
    $filePathParts = $labFilesUri.Split("/")
    $fileName = $filePathParts[$filePathParts.Length - 1]
    Write-Host "File Name: $fileName"

    Write-Host "Download File..."
    (New-Object System.Net.WebClient).DownloadFile($labFilesUri, $labFilesFolder)

    Write-Host "Extract .ZIP file..."
    Expand-Archive -Path $fileName -DestinationPath $labFilesFolder -Force
}