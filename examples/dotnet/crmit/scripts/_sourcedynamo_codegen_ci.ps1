param(
  [string]$CI_ROOT_PATH,
  [string]$CI_RELEASE_VERSION_NUMBER_PADDED_FILE_NAME_FRIENDLY
)

$ValidData = $true        # the tests will set this to false if we find bad data.

if ( [string]::IsNullOrWhiteSpace($CI_ROOT_PATH))
{
  Write-Host "Parameter 1 is empty - please specify the CI Root Path";
  $ValidData = $false
}

if ( [string]::IsNullOrWhiteSpace($CI_RELEASE_VERSION_NUMBER_PADDED_FILE_NAME_FRIENDLY))
{
  Write-Host "Parameter 2 is empty - please specify the CI Release Version Number Padded File Name Friendly";
  $ValidData = $false
}

if ($ValidData)
{
  Write-Host ""
  Write-Host "Parameter 1 (CI Root Path) : $CI_ROOT_PATH"

  Write-Host ""
  Write-Host "Parameter 2 (CI Release Version Number Padded File Name Friendly) : $CI_RELEASE_VERSION_NUMBER_PADDED_FILE_NAME_FRIENDLY"
                                         
  $CI_CODEGEN_DATA_FILE = "$CI_ROOT_PATH/src/crmit.code.gen/Data/ci.code.gen_CrmIt_$CI_RELEASE_VERSION_NUMBER_PADDED_FILE_NAME_FRIENDLY.xlsx"

  Set-Location $CI_ROOT_PATH
  
  Write-Host ""
  Write-Host "Cleaning out bin and obj and node_modules folders so there are no extraneous g.config.json files in there"
  Get-ChildItem .\ -include bin,obj,node_modules -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse }

  Write-Host ""
  Write-Host "CI_CODEGEN_DATA_FILE = $CI_CODEGEN_DATA_FILE"

  Write-Host ""
  Write-Host sourcedynamo action=codegen codegendatafile="$CI_CODEGEN_DATA_FILE" productrootpath="$CI_ROOT_PATH"
  sourcedynamo action=codegen codegendatafile="$CI_CODEGEN_DATA_FILE" productrootpath="$CI_ROOT_PATH"
}
