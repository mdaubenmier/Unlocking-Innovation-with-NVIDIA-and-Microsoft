var OpenAI = require('openai');

module.exports = async function (callback, aiRequest) {
    const openai = new OpenAI({
        apiKey: '<<NGG_API-key>>',
        baseURL: 'https://integrate.api.nvidia.com/v1',
    })
    var messages = "{\"role\":\"user\",\"content\":\"" + aiRequest + "\"}";
    var json_messages = JSON.parse(messages);
    const completion = await openai.chat.completions.create({
        model: "mistralai/mixtral-8x7b-instruct-v0.1",
        messages: [json_messages],
        temperature: 0.5,
        top_p: 1,
        max_tokens: 1024,
        stream: true,
    })
    var result = "";
    var first = true;
    for await (const chunk of completion) {
        if (first) {
            first = false;
            continue;
        }
        result = result + chunk.choices[0]?.delta?.content || '';
    }
    callback(/* error */ null, result);
};
