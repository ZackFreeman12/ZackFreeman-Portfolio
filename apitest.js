const axios = require('axios');

const data = "grant_type=client_credentials&client_id=628d3f5ddf6b4442a10ff0553349b6fb&client_secret=392e4d121bc14deba6c888e752631d6a";
async function test() {
  try {

    const response = await axios.get("https://api.adzuna.com/v1/api/jobs/ca/top_companies?app_id=09c5077b&app_key=e0b226d89a297b4c56bb8ff871192749&what=coffee");



    var output
    response.data.leaderboard.forEach(e => {
      output = output + e.canonical_name + '\n';
    });

    console.log(output);

  }
  catch (error) {
    console.error(error);
  }

}
test();
