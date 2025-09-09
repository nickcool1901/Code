import telebot
from telebot.types import ReplyKeyboardMarkup, KeyboardButton
import os
import json
import random

BOT_TOKEN = "7818173298:AAEy29at-VY3r2JOiWUvvlMZaLJNXl8--6A"
# ADMIN_ID = 1044878407

bot = telebot.TeleBot(BOT_TOKEN)

USERS_FILE = "users.json"
CHANNELS_FILE = "channels.json"
ADS_FILE = "ads.json"

channels = []
ads = {}
selected_channel = {}
user_images = {}

def save_channels():
    with open(CHANNELS_FILE, "w", encoding="utf-8") as f:
        json.dump(channels, f, ensure_ascii=False, indent=4)

def load_channels():
    global channels
    if os.path.exists(CHANNELS_FILE):
        with open(CHANNELS_FILE, "r", encoding="utf-8") as f:
            channels = json.load(f)
    else:
        channels = []
        save_channels()

def save_ads():
    with open(ADS_FILE, "w", encoding="utf-8") as f:
        json.dump(ads, f, ensure_ascii=False, indent=4)

def load_ads():
    global ads
    if os.path.exists(ADS_FILE):
        with open(ADS_FILE, "r", encoding="utf-8") as f:
            ads = json.load(f)
    else:
        ads = {}
        save_ads()

def save_users(users):
    with open(USERS_FILE, "w", encoding="utf-8") as f:
        json.dump(users, f, ensure_ascii=False, indent=4)

def load_users():
    if os.path.exists(USERS_FILE):
        with open(USERS_FILE, "r", encoding="utf-8") as f:
            return json.load(f)
    return []

def create_keyboard(buttons):
    markup = ReplyKeyboardMarkup(resize_keyboard=True)
    for button in buttons:
        markup.add(KeyboardButton(button))
    return markup

def create_start_button():
    markup = ReplyKeyboardMarkup(resize_keyboard=True)
    markup.add(KeyboardButton("Start"))
    return markup

def send_start_to_all():
    users = load_users()
    for user_id in users:
        try:
            bot.send_message(user_id, "✅ Bots palaists! Spied 'Start' lai turpinātu.", reply_markup=create_start_button())
        except Exception:
            pass
        
def create_main_buttons():
    return create_keyboard(["Info", "Pievienot kanālu", "Dzēst kanālu", "Darbības ar izvēlēto kanālu"])

def create_channel_buttons():
    return create_keyboard(channels + ["Atpakaļ"])

def create_action_buttons():
    return create_keyboard(["Sūtīt reklāmu", "Atkārtoti nosūtīt reklāmu", "Noņemt reklāmu", "Atpakaļ"])

def create_ad_buttons(channel):
    if channel in ads and ads[channel]:
        buttons = [ad["text"][:30] for ad in ads[channel] if isinstance(ad, dict) and "text" in ad]  
        return create_keyboard(buttons + ["Atpakaļ"])
    return create_keyboard(["Nav saglabātu reklāmu", "Atpakaļ"])
 
@bot.message_handler(commands=['start'])
def start_command(message):
    users = load_users()
    if message.chat.id not in users:
        users.append(message.chat.id)
        save_users(users)
    bot.send_message(message.chat.id, "✅ Bots palaists! Spied 'Start' lai turpinātu.", reply_markup=create_start_button())

@bot.message_handler(func=lambda message: message.text == "Start")
def show_main_menu(message):
    bot.send_message(message.chat.id, "Izvēlies darbību:", reply_markup=create_main_buttons())

@bot.message_handler(func=lambda message: message.text == "Info")
def send_info(message):
    info_messages = [
        "ℹ️ Šis ir reklāmas bots, kas palīdz sūtīt un pārvaldīt reklāmas kanālos!",
        "📢 Izmanto šo botu, lai viegli pārvaldītu savas reklāmas!",
        "🔹 Pievieno savus kanālus un sūti reklāmas ātri un vienkārši!",
        "💡 Reklāmu pārvaldība vēl nekad nav bijusi tik vienkārša!",
        "🛠️ Izmanto komandas, lai pārvaldītu savus kanālus un reklāmas!",
        "📈 Palielini savu reklāmu sasniedzamību ar šo botu!",
        "🔄 Atkārtoti nosūti reklāmas un saglabā labākās!",
        "⚡ Vienkārša un efektīva reklāmu pārvaldība!",
        "🚀 Automatizē savu reklāmu sūtīšanu ar šo botu!",
        "🎯 Mērķē uz pareizo auditoriju ar labi pārvaldītām reklāmām!"
    ]
    selected_message = random.choice(info_messages)
    bot.send_message(message.chat.id, selected_message, reply_markup=create_main_buttons())

@bot.message_handler(func=lambda message: message.text == "Pievienot kanālu")
def add_channel(message):
    # if message.chat.id != ADMIN_ID:
    #     bot.send_message(message.chat.id, "❌ Tev nav atļaujas pievienot kanālus.")
    #     return
    msg = bot.send_message(message.chat.id, "📝 Ievadi kanāla lietotājvārdu (@kanāls):", reply_markup=create_keyboard(["Atpakaļ"]))
    bot.register_next_step_handler(msg, process_add_channel)

def process_add_channel(message):
    if message.text == "Atpakaļ":
        bot.send_message(message.chat.id, "🔙 Atgriezies izvēlnē.", reply_markup=create_main_buttons())
        return

    channel = message.text.strip()
    
    if not channel.startswith("@"):
        channel = f"@{channel}"

    if channel not in channels:
        channels.append(channel)
        ads[channel] = []
        save_channels()
        save_ads()
        bot.send_message(message.chat.id, f"✅ Kanāls {channel} pievienots!", reply_markup=create_main_buttons())
    else:
        bot.send_message(message.chat.id, "❌ Nederīgs vai jau pievienots kanāls!", reply_markup=create_main_buttons())

@bot.message_handler(func=lambda message: message.text == "Dzēst kanālu")
def remove_channel(message):
    # if message.chat.id != ADMIN_ID or not channels:
    #     bot.send_message(message.chat.id, "❌ Nav kanālu ko dzēst.", reply_markup=create_main_buttons())
    #     return
    msg = bot.send_message(message.chat.id, "📌 Izvēlies kanālu dzēšanai:", reply_markup=create_channel_buttons())
    bot.register_next_step_handler(msg, process_remove_channel)

def process_remove_channel(message):
    if message.text == "Atpakaļ":
        bot.send_message(message.chat.id, "🔙 Atgriezies izvēlnē.", reply_markup=create_main_buttons())
        return
    channel = message.text.strip()
    if channel in channels:
        channels.remove(channel)
        ads.pop(channel, None)
        save_channels()
        save_ads()
        bot.send_message(message.chat.id, f"✅ Kanāls {channel} tika dzēsts.", reply_markup=create_main_buttons())
    else:
        bot.send_message(message.chat.id, "❌ Kanāls nav atrasts!", reply_markup=create_main_buttons())

@bot.message_handler(func=lambda message: message.text == "Darbības ar izvēlēto kanālu")
def action_with_channel(message):
    selected_channel.pop(message.chat.id, None)

    bot.send_message(message.chat.id, "🔹 Vispirms izvēlies kanālu:", reply_markup=create_channel_buttons())
    bot.register_next_step_handler(message, process_choose_channel)

def process_channel_action(message):
    if message.text == "Atpakaļ":
        bot.send_message(message.chat.id, "🔙 Atgriezies pie kanālu izvēles.", reply_markup=create_channel_buttons())
        bot.register_next_step_handler(message, process_choose_channel)
        return
    
    if message.text == "Sūtīt reklāmu":
        send_ad(message)
    elif message.text == "Atkārtoti nosūtīt reklāmu":
        resend_ad(message)
    elif message.text == "Noņemt reklāmu":
        remove_ad(message)
    else:
        bot.send_message(message.chat.id, "❌ Nepareiza izvēle! Izvēlies no saraksta.", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)

@bot.message_handler(func=lambda message: message.text == "Atpakaļ")
def handle_back_button(message):
    channel = selected_channel.get(message.chat.id)

    if channel:
        bot.send_message(message.chat.id, "🔙 Atgriezies pie darbību izvēlnes ar izvēlēto kanālu.", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)
    else:
        bot.send_message(message.chat.id, "🔙 Atgriezies galvenajā izvēlnē.", reply_markup=create_main_buttons())
        
def process_choose_channel(message):
    if message.text == "Atpakaļ":
        bot.send_message(message.chat.id, "🔙 Atgriezies galvenajā izvēlnē.", reply_markup=create_main_buttons())
        return

    if message.text in channels:
        selected_channel[message.chat.id] = message.text
        bot.send_message(message.chat.id, f"✅ Kanāls izvēlēts: {message.text}", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)
    else:
        bot.send_message(message.chat.id, "❌ Kanāls nav atrasts! Izvēlies no saraksta.", reply_markup=create_channel_buttons())
        bot.register_next_step_handler(message, process_choose_channel)
        
# def create_category_buttons():
#     return create_keyboard(["Jaunumi", "Atlaides", "Pakalpojumi", "Preces", "Citi", "Atpakaļ"])

def process_ad_text(message, channel):
    if message.text == "Atpakaļ":
        bot.send_message(message.chat.id, "🔙 Atgriezies pie darbību izvēlnes ar izvēlēto kanālu.", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)
        return

    user_images[message.chat.id] = {"text": message.text.strip(), "photos": []}

    msg = bot.send_message(
        message.chat.id, 
        "📸 Tagad, ja vēlies, sūti attēlus vai nospied 'Pabeigt', lai nosūtītu reklāmu tikai ar tekstu.", 
        reply_markup=create_keyboard(["Pabeigt", "Atpakaļ"])
    )
    bot.register_next_step_handler(msg, collect_images)

@bot.message_handler(func=lambda message: message.text == "Sūtīt reklāmu")
def send_ad(message):
    channel = selected_channel.get(message.chat.id)
    if not channel:
        bot.send_message(message.chat.id, "❌ Kanāls nav izvēlēts!", reply_markup=create_action_buttons())
        return
    
    msg = bot.send_message(
        message.chat.id, 
        "✏️ Ievadi reklāmas tekstu:", 
        reply_markup=create_keyboard(["Atpakaļ"])
    )
    bot.register_next_step_handler(msg, process_ad_text, channel)

def process_send_ad(message, channel):
    if message.chat.id not in user_images:
        user_images[message.chat.id] = {"text": "", "photos": []}

    ad_text = user_images[message.chat.id]["text"] or "📢 Reklāma 📢"
    photos = user_images[message.chat.id]["photos"]

    formatted_ad = {
        "text": f"📢 Reklāma 📢\n\n{ad_text}\n\nKategorija: {message.text.strip()}",
        "photos": photos
    }

    if channel not in ads:
        ads[channel] = []

    ads[channel].append(formatted_ad)
    save_ads()

    try:
        test_message = bot.send_message(channel, "🔍 Pārbaude: Vai bots var sūtīt ziņas?", disable_notification=True)
        bot.delete_message(channel, test_message.message_id)

        if photos:
            media = [telebot.types.InputMediaPhoto(photo_id, caption=formatted_ad["text"] if i == 0 else "") for i, photo_id in enumerate(photos)]
            bot.send_media_group(channel, media)
        else:
            bot.send_message(channel, formatted_ad["text"], parse_mode="Markdown")

        bot.send_message(message.chat.id, "✅ Reklāma veiksmīgi nosūtīta un saglabāta!", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)

    except Exception as e:
        bot.send_message(message.chat.id, f"❌ Kļūda reklāmas nosūtīšanā: {str(e)}", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)

    del user_images[message.chat.id]
    
@bot.message_handler(content_types=['photo', 'text'])
def collect_images(message):
    channel = selected_channel.get(message.chat.id)

    if not channel:
        handle_back_button(message)
        return

    if message.chat.id not in user_images or "text" not in user_images[message.chat.id]:
        bot.send_message(message.chat.id, "❌ Nav aktīvas reklāmas rediģēšanas sesijas.", reply_markup=create_action_buttons())
        return  

    if message.text == "Pabeigt":
        process_send_ad(message, channel)  
        return

    if message.text == "Atpakaļ":
        bot.send_message(message.chat.id, "🔙 Atgriezies pie reklāmas teksta ievades.", reply_markup=create_keyboard(["Atpakaļ"]))
        bot.register_next_step_handler(message, process_ad_text, channel)
        return

    if message.content_type == 'photo':
        photo_id = message.photo[-1].file_id
        user_images[message.chat.id]["photos"].append(photo_id)

        bot.send_message(message.chat.id, "📸 Attēls saglabāts! Sūti vēl vai nospied 'Pabeigt'.",
                         reply_markup=create_keyboard(["Pabeigt", "Atpakaļ"]))
        bot.register_next_step_handler(message, collect_images)  
        return

    bot.send_message(message.chat.id, "❌ Lūdzu, sūti tikai attēlus vai izvēlies 'Pabeigt'.",
                     reply_markup=create_keyboard(["Pabeigt", "Atpakaļ"]))
    bot.register_next_step_handler(message, collect_images)  
    
@bot.message_handler(func=lambda message: message.text == "Atkārtoti nosūtīt reklāmu")
def resend_ad(message):
    channel = selected_channel.get(message.chat.id)

    if not channel:
        bot.send_message(message.chat.id, "❌ Kanāls nav izvēlēts!", reply_markup=create_action_buttons())
        return

    if channel not in ads or not ads[channel]:  
        bot.send_message(message.chat.id, "❌ Šim kanālam nav saglabātu reklāmu!", reply_markup=create_action_buttons())

        bot.send_message(message.chat.id, "🔙 Atgriezies pie darbību izvēlnes ar izvēlēto kanālu.", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)
        return

    msg = bot.send_message(message.chat.id, "📢 Izvēlies reklāmu atkārtotai nosūtīšanai:", 
                           reply_markup=create_ad_buttons(channel))
    bot.register_next_step_handler(msg, process_resend_ad, channel)

def process_resend_ad(message, channel):
    if message.text == "Atpakaļ":
        bot.send_message(message.chat.id, "🔙 Atgriezies pie darbību izvēlnes ar izvēlēto kanālu.", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)
        return

    if channel not in ads or not ads[channel]:  
        bot.send_message(message.chat.id, "❌ Šim kanālam nav saglabātu reklāmu!", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)
        return

    matched_ad = next((ad for ad in ads[channel] if ad["text"].startswith(message.text.strip())), None)

    if matched_ad:
        try:
            test_message = bot.send_message(channel, "🔍 Pārbaude: Vai bots var sūtīt ziņas?", disable_notification=True)
            bot.delete_message(channel, test_message.message_id)
            if matched_ad["photos"]:
                media = [telebot.types.InputMediaPhoto(photo_id, caption=matched_ad["text"] if i == 0 else "") for i, photo_id in enumerate(matched_ad["photos"])]
                bot.send_media_group(channel, media)
            else:
                bot.send_message(channel, matched_ad["text"], parse_mode="Markdown")

            bot.send_message(message.chat.id, "✅ Reklāma veiksmīgi nosūtīta atkārtoti!", reply_markup=create_action_buttons())
            bot.register_next_step_handler(message, process_channel_action)

        except Exception as e:
            bot.send_message(message.chat.id, f"❌ Kļūda reklāmas nosūtīšanā: {str(e)}", reply_markup=create_action_buttons())
            bot.register_next_step_handler(message, process_channel_action)
    else:
        bot.send_message(message.chat.id, "❌ Reklāma nav atrasta! Izvēlies no saraksta.", reply_markup=create_ad_buttons(channel))
        bot.register_next_step_handler(message, process_resend_ad, channel)

@bot.message_handler(func=lambda message: message.text == "Noņemt reklāmu")
def remove_ad(message):
    bot.clear_step_handler_by_chat_id(message.chat.id)

    channel = selected_channel.get(message.chat.id)

    if not channel:
        bot.send_message(message.chat.id, "❌ Nav izvēlēts kanāls! Vispirms izvēlies kanālu.", reply_markup=create_channel_buttons())
        return

    if channel not in ads or not ads[channel]:  
        bot.send_message(message.chat.id, "❌ Šim kanālam nav saglabātu reklāmu!", reply_markup=create_action_buttons())

        bot.send_message(message.chat.id, "🔙 Atgriezies pie darbību izvēlnes ar izvēlēto kanālu.", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)
        return

    msg = bot.send_message(message.chat.id, "🗑️ Izvēlies reklāmu dzēšanai:", reply_markup=create_ad_buttons(channel))
    bot.register_next_step_handler(msg, process_remove_ad, channel)

def process_remove_ad(message, channel):
    if message.text == "Atpakaļ":
        bot.send_message(message.chat.id, "🔙 Atgriezies pie darbību izvēlnes ar izvēlēto kanālu.", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)
        return

    if channel not in ads or not ads[channel]:  
        bot.send_message(message.chat.id, "❌ Šim kanālam nav saglabātu reklāmu!", reply_markup=create_action_buttons())
        bot.register_next_step_handler(message, process_channel_action)
        return

    matched_ad = next((ad for ad in ads[channel] if ad["text"].startswith(message.text.strip())), None)

    if matched_ad:
        try:
            ads[channel].remove(matched_ad)
            save_ads()
            bot.send_message(message.chat.id, "✅ Reklāma veiksmīgi dzēsta!", reply_markup=create_action_buttons())

            if not ads[channel]:
                bot.send_message(message.chat.id, "ℹ️ Šim kanālam vairs nav saglabātu reklāmu.", reply_markup=create_action_buttons())

            bot.register_next_step_handler(message, process_channel_action)

        except Exception as e:
            bot.send_message(message.chat.id, f"❌ Kļūda dzēšot reklāmu: {str(e)}", reply_markup=create_action_buttons())
            bot.register_next_step_handler(message, process_channel_action)
    else:
        bot.send_message(message.chat.id, "❌ Reklāma nav atrasta! Izvēlies no saraksta.", reply_markup=create_ad_buttons(channel))
        bot.register_next_step_handler(message, process_remove_ad, channel)

    matched_ad = next((ad for ad in ads[channel] if ad["text"].startswith(message.text.strip())), None)

    if matched_ad:
        try:
            ads[channel].remove(matched_ad)
            save_ads()
            bot.send_message(message.chat.id, "✅ Reklāma veiksmīgi dzēsta!", reply_markup=create_action_buttons())
            bot.register_next_step_handler(message, process_channel_action)

            if not ads[channel]:
                bot.send_message(message.chat.id, "ℹ️ Šim kanālam vairs nav saglabātu reklāmu.", reply_markup=create_action_buttons())

        except Exception as e:
            bot.send_message(message.chat.id, f"❌ Kļūda dzēšot reklāmu: {str(e)}", reply_markup=create_action_buttons())
            bot.register_next_step_handler(message, process_channel_action)
    else:
        bot.send_message(message.chat.id, "❌ Reklāma nav atrasta! Izvēlies no saraksta.", reply_markup=create_ad_buttons(channel))
        bot.register_next_step_handler(message, process_remove_ad, channel)
        
load_channels()
load_ads()

print("✅ Bots ir veiksmīgi palaists!")
send_start_to_all()
bot.polling(none_stop=True)