param(
  [string]$WI_ROOT_PATH,
  [string]$WI_RELEASE_VERSION_NUMBER_PADDED_FILE_NAME_FRIENDLY
)

$ValidData = $true        # the tests will set this to false if we find bad data.

if ( [string]::IsNullOrWhiteSpace($WI_ROOT_PATH))
{
  Write-Host "Parameter 1 is empty - please specify the WI Root Path";
  $ValidData = $false
}

if ( [string]::IsNullOrWhiteSpace($WI_RELEASE_VERSION_NUMBER_PADDED_FILE_NAME_FRIENDLY))
{
  Write-Host "Parameter 2 is empty - please specify the WI Release Version Number Padded File Name Friendly";
  $ValidData = $false
}

if ($ValidData)
{
  Write-Host ""
  Write-Host "Parameter 1 (WI Root Path) : $WI_ROOT_PATH"

  Write-Host ""
  Write-Host "Parameter 2 (WI Release Version Number Padded File Name Friendly) : $WI_RELEASE_VERSION_NUMBER_PADDED_FILE_NAME_FRIENDLY"
                                         
  $WI_CODEGEN_DATA_FILE = "$WI_ROOT_PATH/src/weatherit.code.gen/Data/wi.code.gen_WeatherIt_$WI_RELEASE_VERSION_NUMBER_PADDED_FILE_NAME_FRIENDLY.xlsx"

  Write-Host ""

  Write-Host "WI_CODEGEN_DATA_FILE = $WI_CODEGEN_DATA_FILE"

  Write-Host ""

  Write-Host sourcedynamo action=codegen codegendatafile="$WI_CODEGEN_DATA_FILE" productrootpath="$WI_ROOT_PATH"
  sourcedynamo action=codegen codegendatafile="$WI_CODEGEN_DATA_FILE" productrootpath="$WI_ROOT_PATH"
}
