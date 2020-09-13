const discordDomains = [
    'discordapp.com',
    'discord.com'
];

const teamsDomains = [
    'outlook.office.com'
]



function onReady() {
    let clipboard = new ClipboardJS('.hooksharpHook');
    
    clipboard.on('success', function (e) {
       fireToast('Copied to your clipboard!', 'success'); 
    });  
}

async function onParseClick() {
    let incomingHook = $('#inboundHook').val();
    if (incomingHook === '' || incomingHook === undefined) {
        fireToast('Looks like you forgot to enter your Current Webhook!', 'error');
        return false;
    }
    let result = await HandleRequestAndParse();
    
    if (result) {
        fireToast('Parse was successful!', 'success');
        
        $('#hooksharpHookContainer').removeAttr('hidden');
        $('#parseButton').text('Parse another!');
        
    } else {
        fireToast('Parse failed! Make sure your Current Webhook is valid and you selected the proper Handler.', 'error');
    }
}


async function HandleRequestAndParse() {
    let provider = await DetectProvider();
    switch (provider) {
        case 'bitbucket-server':
            console.log('Detected Bitbucket Server - Parsing');
            let handler = await DetectHandler();
            await Parse(provider, handler);
            return true;
        
        case 'jira':
            console.log('Detected JIRA')
            return true;
            
        default:
            return false
    }
}

async function DetectProvider() {
    return $('#provider').val();
}

async function DetectHandler() {
    return $('#handler').val();
}

async function Parse(provider, handler) {
    let incomingHook = $('#inboundHook').val();
    
    if (incomingHook) {
        if (handler === 'discord') {
            for (const domain of discordDomains) {
                if (incomingHook.includes(domain)) {
                    return await ParseDiscord(incomingHook, provider, domain);
                }
            }
        }

        if (handler === 'teams') {
            for (const domain of teamsDomains) {
                if (incomingHook.includes(domain)) {
                    return await ParseTeams(incomingHook, provider);
                }
            }
        }
    }
    
}

async function ParseDiscord(discordHook, provider, domain) {    
    const discordPart = `https://${domain}/api/webhooks/`
    const hooksharpPart = `${window.location.origin}/webhooks/discord/${provider}/`;
    const hooksharpUrl = discordHook.replace(discordPart, hooksharpPart);    
    $(`#hooksharpHook`).val(hooksharpUrl);
    
    return true;
}

async function ParseTeams(teamsHook, provider) {
    
}

function fireToast(title, icon) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        onOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    })

    Toast.fire({
        icon: icon,
        title: title
    })
}