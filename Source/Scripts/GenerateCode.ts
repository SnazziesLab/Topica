import path from "path";
import fse from "fs-extra";
import { execute } from "./Execute";

const tempFolder = path.join(__dirname, "../temp");
const version = "1.0.0";
const appName = "Topica";

if (fse.existsSync(tempFolder)) fse.removeSync(tempFolder);
fse.mkdirSync(tempFolder);
collectSwaggerFoldersIntoTemp([
  "Topica.Server/Topica.Server/Swagger",
]);


const CodeGenPath = "./Clients";
if (fse.existsSync(CodeGenPath)) 
  fse.removeSync(CodeGenPath);

if (!fse.existsSync(CodeGenPath))
  fse.mkdirsSync(CodeGenPath);

execute(`npx @openapitools/openapi-generator-cli version-manager set 7.2.0`)
execute(`npx @openapitools/openapi-generator-cli generate -i temp/Swagger/${appName}.Server/v1/Swagger.json -g rust -o ${CodeGenPath}/v1/Rust/${appName}.Client --additional-properties=packageVersion=${version},packageName=${appName}.Client`)
execute(`npx @openapitools/openapi-generator-cli generate -i temp/Swagger/${appName}.Server/v1/Swagger.json -g typescript-fetch -o ${CodeGenPath}/v1/TypeScript/${appName}.Client -p npmName=${appName}.Client --additional-properties=npmVersion=${version},stringEnums=true`)
execute(`npx @openapitools/openapi-generator-cli generate -i temp/Swagger/${appName}.Server/v1/Swagger.json -g go -o ${CodeGenPath}/v1/Go/${appName}.Client --additional-properties=enumClassPrefix=true,packageVersion=${version},packageName=${appName}.Client`)

function collectSwaggerFoldersIntoTemp(swaggerPaths: string[]) {
  swaggerPaths.forEach((e) => {
    // To copy a folder or file
    fse.copySync(e, path.join(tempFolder, "Swagger", e.split('/')[1]), {
      errorOnExist: false,
    });
  });
}
