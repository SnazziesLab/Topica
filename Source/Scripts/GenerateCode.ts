import path from "path";
import fse from "fs-extra";
import { execute } from "./Execute";

const tempFolder = path.join(__dirname, "../temp");
const version = fse.readFileSync(path.join(__dirname, "../version.txt"));
const appName = "Topica";
const lowered = "Topica".toLowerCase();
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

const swaggerFile = `temp/Swagger/${appName}.Server/Swagger.json`
execute(`npx @openapitools/openapi-generator-cli version-manager set 7.2.0`)
execute(`npx @openapitools/openapi-generator-cli generate -i ${swaggerFile} -g rust -o ${CodeGenPath}/Rust/${appName}.Client --additional-properties=packageVersion=${version},packageName=${lowered}_client`)
execute(`npx @openapitools/openapi-generator-cli generate -i ${swaggerFile} -g typescript-fetch -o ${CodeGenPath}/TypeScript/${appName}.Client -p npmName=@${lowered}/client --additional-properties=npmVersion=${version},stringEnums=true`)
execute(`npx @openapitools/openapi-generator-cli generate -i ${swaggerFile} -g go -o ${CodeGenPath}/Go/${appName}.Client --additional-properties=enumClassPrefix=true,packageVersion=${version},packageName=${lowered}client`)

//execute(`cd ${CodeGenPath}/TypeScript/${appName}.Client && npm i && npm run build`)

function collectSwaggerFoldersIntoTemp(swaggerPaths: string[]) {
  swaggerPaths.forEach((e) => {
    // To copy a folder or file
    fse.copySync(e, path.join(tempFolder, "Swagger", e.split('/')[1]), {
      errorOnExist: false,
    });
  });
}
